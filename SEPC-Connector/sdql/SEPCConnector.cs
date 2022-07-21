// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SEPCConnector
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public abstract class SEPCConnector
  {
    protected readonly ILog LOG = LogManager.GetLogger(typeof (SEPCConnector));
    private static readonly int MIN_TIME_BETWEEN_RECONNECTS_IN_MINUTES = 1;
    private volatile SEPCConnectorStep ConnectorStep = SEPCConnectorStep.GET_INITIAL_DATA;
    protected IEntityChangeBatchProcessingMonitor EntityChangeBatchProcessingMonitor;
    protected List<IConnectorListener> ConnectorListeners = new List<IConnectorListener>();
    protected List<IStreamedConnectorListener> StreamedConnectorListeners = new List<IStreamedConnectorListener>();
    private volatile bool Stopped;
    protected TimeSpan TimeBetweenReconnects = TimeSpan.FromMinutes((double) SEPCConnector.MIN_TIME_BETWEEN_RECONNECTS_IN_MINUTES);

    protected abstract void Execute(object subscriptionName);

    public virtual void Start(string subscriptionName)
    {
      if (this.LOG.IsInfoEnabled)
      {
        this.LOG.Info((object) "Starting connector...");
        this.LOG.Info((object) "Starting connector background thread...");
      }
      Thread thread = new Thread((ThreadStart) (() => this.Execute((object) subscriptionName)));
      if (this.LOG.IsInfoEnabled)
        this.LOG.Info((object) "Connector started...");
      thread.IsBackground = false;
      thread.Start();
    }

    public void Stop()
    {
      if (this.LOG.IsInfoEnabled)
        this.LOG.Info((object) "Stopping connector...");
      this.Stopped = true;
    }

    protected void NotifyInitialDumpToBeRetrieved()
    {
      foreach (IStreamedConnectorListener connectorListener in this.StreamedConnectorListeners)
      {
        try
        {
          connectorListener.NotifyInitialDumpToBeRetrieved();
        }
        catch (Exception ex)
        {
          this.LOG.Error((object) string.Format("An error occurred while notifying listener on initial dump to be retrieved: {0}", (object) connectorListener), ex);
        }
      }
    }

    protected void NotifyInitialDumpRetrieved()
    {
      foreach (IStreamedConnectorListener connectorListener in this.StreamedConnectorListeners)
      {
        try
        {
          connectorListener.NotifyInitialDumpRetrieved();
        }
        catch (Exception ex)
        {
          this.LOG.Error((object) string.Format("An error occurred while notifying listener on initial dump retrieved: {0}", (object) connectorListener), ex);
        }
      }
    }

    protected void NotifyPartialInitialDumpRetrieved(List<Entity> entities)
    {
      foreach (IStreamedConnectorListener connectorListener in this.StreamedConnectorListeners)
      {
        try
        {
          connectorListener.NotifyPartialInitialDumpRetrieved(entities);
        }
        catch (Exception ex)
        {
          this.LOG.Error((object) string.Format("An error occurred while notifying listener on partial initial dump retrieved: {0}", (object) connectorListener), ex);
        }
      }
    }

    protected void NotifyInitialDump(List<Entity> initialDump) => this.ConnectorListeners.ForEach((Action<IConnectorListener>) (listener => listener.NotifyInitialDump(initialDump)));

    protected void NotifyUpdate(
      SDQLUpdateData updateData,
      string subscriptionId,
      string subscriptionChecksum)
    {
      EntityChangeBatch entityChangeBatch = new EntityChangeBatch(updateData.BatchId, updateData.BatchUuid, updateData.CreateTime, updateData.EntityChanges, subscriptionId, subscriptionChecksum);
      foreach (IConnectorListener connectorListener in this.ConnectorListeners)
      {
        try
        {
          connectorListener.NotifyEntityUpdates(entityChangeBatch);
        }
        catch (Exception ex)
        {
          this.LOG.Error((object) string.Format("An error occurred {0} while notifying listener: {1}", (object) entityChangeBatch.Id, (object) connectorListener), ex);
        }
      }
      foreach (IStreamedConnectorListener connectorListener in this.StreamedConnectorListeners)
      {
        try
        {
          connectorListener.NotifyEntityUpdatesRetrieved(entityChangeBatch);
        }
        catch (Exception ex)
        {
          this.LOG.Error((object) string.Format("An error occurred {0} while notifying listener: {1}", (object) entityChangeBatch.Id, (object) connectorListener), ex);
        }
      }
    }

    public SEPCConnectorStep GetNextConnectorStep() => this.ConnectorStep;

    public void SetNextConnectorStep(SEPCConnectorStep step) => this.ConnectorStep = step;

    public bool ConnectorWasStopped() => this.Stopped;

    public void SetReconnectInterval(TimeSpan interval)
    {
      if (interval.TotalMinutes < (double) SEPCConnector.MIN_TIME_BETWEEN_RECONNECTS_IN_MINUTES)
        throw new ArgumentOutOfRangeException(nameof (interval), "The specified time is lower than 1 minute.");
      this.TimeBetweenReconnects = interval;
    }

    protected void WaitBeforeSendingSubscribeRequest()
    {
      this.LOG.Info((object) string.Format("Waiting {0} seconds before sending next Subscribe Request...", (object) this.TimeBetweenReconnects.TotalSeconds));
      Thread.Sleep(this.TimeBetweenReconnects);
    }

    protected bool ShouldUpdateResume()
    {
      bool flag = this.EntityChangeBatchProcessingMonitor != null;
      this.LOG.Info((object) ("Checking condition for update resume: " + (flag ? "yes" : "entity change batch processor not set, could not retrieve last batch id for update resume")));
      return flag;
    }

    public void AddConnectorListener(IConnectorListener listener) => this.ConnectorListeners.Add(listener);

    public void AddStreamedConnectorListener(IStreamedConnectorListener listener) => this.StreamedConnectorListeners.Add(listener);

    public void SetEntityChangeBatchProcessingMonitor(IEntityChangeBatchProcessingMonitor monitor) => this.EntityChangeBatchProcessingMonitor = monitor;
  }
}
