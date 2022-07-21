// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SEPCPushConnection
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System.Net.Sockets;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SEPCPushConnection
  {
    private readonly string Host;
    private readonly int Port;
    private TcpClient Connection;
    private NetworkStream Stream;

    public SEPCPushConnection(string host, int port)
    {
      this.Host = host;
      this.Port = port;
    }

    public void Connect()
    {
      this.Connection = new TcpClient(this.Host, this.Port);
      this.Stream = this.Connection.GetStream();
    }

    public void Disconnect()
    {
      if (this.Connection == null)
        return;
      this.Connection.Close();
    }

    public SDQLConstruct Read() => SDQLXMLReaderUtil.ReadPDUFromPushStream(this.Stream);

    public void Write(SDQLConstruct construct) => SDQLXMLWriterUtil.WritePDU(this.Stream, construct);
  }
}
