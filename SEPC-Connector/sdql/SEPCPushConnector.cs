// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SEPCPushConnector
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SEPCPushConnector : SEPCConnector
  {
    private readonly SEPCPushConnection Connection;
    private volatile bool Connected;
    private string SubscriptionId;
    private string SubscriptionChecksum;
    private DateTime TimeOfLastActivityFromServer;
    private readonly TimeSpan TimeBetweenServerCheck = TimeSpan.FromSeconds(5.0);

    private TimeSpan MaxServerIdleTime { get; set; } = TimeSpan.FromSeconds(30.0);

    public SEPCPushConnector(string host, int port) => this.Connection = new SEPCPushConnection(host, port);

    public override void Start(string subscriptionName)
    {
      Task.Run((Action) (() => this.CheckServerActivity()));
      base.Start(subscriptionName);
    }

    public void StartWithResume(
      string subscriptionName,
      string subscriptionId,
      string subscriptionChecksum,
      string lastAppliedEntityChangeBatchUuid)
    {
      if (string.IsNullOrEmpty(subscriptionName))
        throw new ArgumentException("Subscription name is null or empty.");
      if (string.IsNullOrEmpty(subscriptionId))
        throw new ArgumentException("Subscription ID is null or empty.");
      if (string.IsNullOrEmpty(subscriptionChecksum))
        throw new ArgumentException("Subscription checksum is null or empty.");
      if (string.IsNullOrEmpty(lastAppliedEntityChangeBatchUuid))
        throw new ArgumentException("Last applied batch UUID is null or empty.");
      this.SubscriptionId = subscriptionId;
      this.SubscriptionChecksum = subscriptionChecksum;
      if (this.EntityChangeBatchProcessingMonitor == null)
        throw new NotSupportedException("Start with resume requires EntityChangeBatchProcessingMonitor to be not null.");
      if (!lastAppliedEntityChangeBatchUuid.Equals(this.EntityChangeBatchProcessingMonitor.GetLastAppliedEntityChangeBatchUuid()))
        throw new NotSupportedException("Start with resume requires EntityChangeBatchProcessingMonitor's lastAppliedEntityChangeBatchUuid to be equal to " + lastAppliedEntityChangeBatchUuid + ".");
      this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE_RESUME);
      this.Start(subscriptionName);
    }

    public void CheckServerActivity()
    {
      this.LOG.Info((object) "ServerActivityMonitor started");
      while (!this.ConnectorWasStopped())
      {
        DateTime now = DateTime.Now;
        if (this.Connected && now - this.TimeOfLastActivityFromServer > this.MaxServerIdleTime)
        {
          this.LOG.Info((object) string.Format("No activity from server in the last {0} seconds.", (object) (now - this.TimeOfLastActivityFromServer).TotalSeconds));
          this.Disconnect();
        }
        Thread.Sleep(this.TimeBetweenServerCheck);
      }
      this.LOG.Info((object) "ServerActivityMonitor stopped.");
    }

    protected override void Execute(object subscriptionName)
    {
      while (!this.ConnectorWasStopped())
      {
        SEPCConnectorStep nextConnectorStep = this.GetNextConnectorStep();
        if (SEPCConnectorStep.GET_INITIAL_DATA == nextConnectorStep || SEPCConnectorStep.GET_UPDATE_RESUME == nextConnectorStep)
        {
          this.Connected = this.TryToConnectIfNotStopped();
          if (!this.Connected)
            return;
        }
        switch (nextConnectorStep)
        {
          case SEPCConnectorStep.GET_UPDATE:
            try
            {
              SDQLUpdateData updateData = this.ReadUpdateData();
              if (updateData != null)
              {
                this.NotifyUpdate(updateData, this.SubscriptionId, this.SubscriptionChecksum);
                continue;
              }
              continue;
            }
            catch (Exception ex)
            {
              this.LOG.Warn((object) "", ex);
              this.Disconnect();
              if (this.ShouldUpdateResume())
              {
                this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE_RESUME);
                continue;
              }
              this.SetNextConnectorStep(SEPCConnectorStep.TRY_RECONNECT_AFTER_WAITING);
              continue;
            }
          case SEPCConnectorStep.GET_INITIAL_DATA:
            try
            {
              string[] strArray = this.SendSubscribeRequest((string) subscriptionName);
              this.SubscriptionId = strArray[0];
              this.SubscriptionChecksum = strArray[1];
              this.NotifyInitialDumpToBeRetrieved();
              if (this.ConnectorListeners.Count > 0)
              {
                List<Entity> initialDump = this.ReadInitialData();
                foreach (IConnectorListener connectorListener in this.ConnectorListeners)
                  connectorListener.NotifyInitialDump(initialDump);
              }
              else
                this.ReadInitialDataAndNotifyStreamedListeners();
              this.NotifyInitialDumpRetrieved();
              this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE);
              continue;
            }
            catch (Exception ex)
            {
              this.LOG.Warn((object) "", ex);
              this.Disconnect();
              this.SetNextConnectorStep(SEPCConnectorStep.TRY_RECONNECT_AFTER_WAITING);
              continue;
            }
          case SEPCConnectorStep.GET_UPDATE_RESUME:
            try
            {
              SDQLUpdateData dataResumeRequest = this.SendGetNextUpdateDataResumeRequest((string) subscriptionName, this.SubscriptionId, this.SubscriptionChecksum);
              if (dataResumeRequest != null)
                this.NotifyUpdate(dataResumeRequest, this.SubscriptionId, this.SubscriptionChecksum);
              this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE);
              continue;
            }
            catch (IOException ex)
            {
              this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE_RESUME);
              Thread.Sleep(this.TimeBetweenServerCheck);
              continue;
            }
            catch (Exception ex)
            {
              this.LOG.Warn((object) ex);
              this.Disconnect();
              if (this.ShouldUpdateResume())
              {
                if (ex is SDQLErrorException sdqlErrorException6)
                {
                  if (sdqlErrorException6.Error.Code != 400)
                  {
                    this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE_RESUME);
                    Thread.Sleep(this.TimeBetweenServerCheck);
                    continue;
                  }
                  this.SetNextConnectorStep(SEPCConnectorStep.TRY_RECONNECT_AFTER_WAITING);
                  continue;
                }
                this.SetNextConnectorStep(SEPCConnectorStep.GET_UPDATE_RESUME);
                Thread.Sleep(this.TimeBetweenServerCheck);
                continue;
              }
              this.SetNextConnectorStep(SEPCConnectorStep.TRY_RECONNECT_AFTER_WAITING);
              continue;
            }
          case SEPCConnectorStep.TRY_RECONNECT_AFTER_WAITING:
            this.WaitBeforeSendingSubscribeRequest();
            this.SetNextConnectorStep(SEPCConnectorStep.GET_INITIAL_DATA);
            continue;
          default:
            continue;
        }
      }
      this.LOG.Info((object) "Connector stopped...unsubscribing...");
      this.SendUnsubscribeRequest((string) subscriptionName, this.SubscriptionId);
      this.Disconnect();
      this.Stop();
    }

    private SDQLUpdateData ReadUpdateData()
    {
      string str = "An error occurred while reading update data...";
      try
      {
        this.LOG.Debug((object) "Reading Update Data...");
        SDQLUpdateData sdqlUpdateData = this.TryReadExpectedSdqlConstructIfNotStopped<SDQLUpdateData>();
        this.LOG.Debug((object) string.Format("Update data read: {0}", (object) sdqlUpdateData));
        return sdqlUpdateData;
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) str, ex);
        throw ex;
      }
    }

    private SDQLUpdateData SendGetNextUpdateDataResumeRequest(
      string subscriptionName,
      string subscriptionId,
      string subscriptionChecksum)
    {
      string str = "An error occurred while sending update resume request";
      try
      {
        string entityChangeBatchUuid = this.EntityChangeBatchProcessingMonitor.GetLastAppliedEntityChangeBatchUuid();
        this.LOG.Info((object) ("Sending an Update-Resume Request... lastAppliedEntityChangeBatchUUID was " + entityChangeBatchUuid));
        this.WriteSDQLConstruct((SDQLConstruct) new SDQLUpdateDataResumeRequest(subscriptionName, subscriptionId, subscriptionChecksum, entityChangeBatchUuid));
        this.LOG.Info((object) "Reading Update Data...");
        SDQLUpdateData sdqlUpdateData = this.TryReadExpectedSdqlConstructIfNotStopped<SDQLUpdateData>();
        this.LOG.Info((object) string.Format("Update data read: {0}", (object) sdqlUpdateData));
        return sdqlUpdateData;
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) str, ex);
        throw ex;
      }
    }

    private void SendUnsubscribeRequest(string subscriptionName, string subscriptionId)
    {
      this.LOG.Info((object) "Sending an Unsubscribe Request...");
      this.WriteSDQLConstruct((SDQLConstruct) new SDQLUnsubscribeRequest(subscriptionName, subscriptionId));
      this.LOG.Info((object) "Unsubscribed...");
    }

    private List<Entity> ReadInitialData()
    {
      string str = "An error occurred while reading initial data...";
      List<Entity> entityList = new List<Entity>();
      try
      {
        this.LOG.Info((object) "Reading Initial Data...");
        bool flag = false;
        do
        {
          this.LOG.Info((object) "Reading Initial Data batch...");
          SDQLInitialData sdqlInitialData = this.TryReadExpectedSdqlConstructIfNotStopped<SDQLInitialData>();
          if (sdqlInitialData != null)
          {
            List<Entity> entities = sdqlInitialData.Entities;
            this.LOG.Info((object) string.Format("Read batch [{0}] containing {1} entities. [{2} batches left]", (object) sdqlInitialData.BatchId, (object) entities.Count, (object) sdqlInitialData.BatchesLeft));
            entityList.AddRange((IEnumerable<Entity>) entities);
            flag = sdqlInitialData.DumpComplete;
          }
        }
        while (!(this.ConnectorWasStopped() | flag));
        this.LOG.Info((object) string.Format("Read initial data. [{0} entities]", (object) entityList.Count));
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) str, ex);
        throw ex;
      }
      return entityList;
    }

    private void ReadInitialDataAndNotifyStreamedListeners()
    {
      string str = "An error occurred while reading initial data...";
      try
      {
        int num = 0;
        this.LOG.Info((object) "Reading Initial Data...");
        bool flag = false;
        do
        {
          this.LOG.Info((object) "Reading Initial Data batch...");
          SDQLInitialData sdqlInitialData = this.TryReadExpectedSdqlConstructIfNotStopped<SDQLInitialData>();
          if (sdqlInitialData != null)
          {
            List<Entity> entities = sdqlInitialData.Entities;
            num += entities.Count;
            this.LOG.Info((object) string.Format("Read batch [{0}] containing {1} entities. [{2} batches left]", (object) sdqlInitialData.BatchId, (object) entities.Count, (object) sdqlInitialData.BatchesLeft));
            this.NotifyPartialInitialDumpRetrieved(entities);
            flag = sdqlInitialData.DumpComplete;
          }
        }
        while (!(this.ConnectorWasStopped() | flag));
        this.LOG.Info((object) string.Format("Read initial data. [{0} entities]", (object) num));
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) str, ex);
        throw ex;
      }
    }

    private bool TryToConnectIfNotStopped()
    {
      this.LOG.Info((object) "Trying to connect to SEPC Publisher app...");
      while (!this.ConnectorWasStopped())
      {
        try
        {
          this.Connection.Connect();
          this.LOG.Info((object) "Connected...");
          this.TimeOfLastActivityFromServer = DateTime.Now;
          return true;
        }
        catch (Exception ex1)
        {
          this.LOG.Error((object) ("Failed to connect..." + ex1.Message), ex1);
          this.LOG.Info((object) string.Format("Waiting {0} seconds before reconnecting...", (object) this.TimeBetweenReconnects.TotalSeconds));
          try
          {
            Thread.Sleep(this.TimeBetweenReconnects);
          }
          catch (Exception ex2)
          {
            this.LOG.Error((object) "An error occurred while waiting to reconnect...", ex2);
          }
        }
      }
      return false;
    }

    private string[] SendSubscribeRequest(string subscriptionName)
    {
      string str = "An error occurred while subscribing..";
      try
      {
        this.LOG.Info((object) "Sending a Subscribe Request...");
        this.WriteSDQLConstruct((SDQLConstruct) new SDQLSubscribeRequest(subscriptionName));
        this.LOG.Info((object) "Waiting for the Subscribe Response...");
        SDQLSubscribeResponse subscribeResponse = this.TryReadExpectedSdqlConstructIfNotStopped<SDQLSubscribeResponse>();
        string subscriptionId = subscribeResponse.SubscriptionId;
        string subscriptionChecksum = subscribeResponse.SubscriptionChecksum;
        this.LOG.Info((object) ("The subscription is now set up. The subscription id is '" + subscriptionId + "', checksum is " + subscriptionChecksum + "."));
        return new string[2]
        {
          subscriptionId,
          subscriptionChecksum
        };
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) str, ex);
        throw;
      }
    }

    private T TryReadExpectedSdqlConstructIfNotStopped<T>() where T : SDQLConstruct
    {
      SDQLConstruct sdqlConstruct;
      do
      {
        sdqlConstruct = this.Connection.Read();
        this.TimeOfLastActivityFromServer = DateTime.Now;
        if (sdqlConstruct == null)
          return default (T);
        if (sdqlConstruct.GetType().Equals(typeof (SDQLPingRequest)))
          this.WriteSDQLConstruct((SDQLConstruct) new SDQLPingResponse(((SDQLPingRequest) sdqlConstruct).Id));
        else
          goto label_4;
      }
      while (!this.ConnectorWasStopped());
      goto label_9;
label_4:
      if (sdqlConstruct.GetType().Equals(typeof (SDQLError)))
        throw new SDQLErrorException((SDQLError) sdqlConstruct);
      return sdqlConstruct.GetType().Equals(typeof (T)) ? (T) sdqlConstruct : throw new Exception(string.Format("Read unexpected SDQL construct: {0}", (object) sdqlConstruct));
label_9:
      return default (T);
    }

    private void WriteSDQLConstruct(SDQLConstruct construct) => this.Connection.Write(construct);

    private void Disconnect()
    {
      try
      {
        this.LOG.Info((object) "Disconnecting...");
        this.Connection.Disconnect();
        this.Connected = false;
        this.LOG.Info((object) "Disconnected...");
      }
      catch (Exception ex)
      {
        this.LOG.Error((object) "Failed disconnect...", ex);
      }
    }

    public string GetSubscriptionId() => this.SubscriptionId;

    public string GetSubscriptionChecksum() => this.SubscriptionChecksum;
  }
}
