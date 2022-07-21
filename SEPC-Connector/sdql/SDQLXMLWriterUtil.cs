// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLXMLWriterUtil
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.util;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace com.oddsmatrix.sepc.connector.sdql
{
  internal static class SDQLXMLWriterUtil
  {
    internal static void WritePDU(NetworkStream stream, SDQLConstruct construct)
    {
      StringBuilder output = new StringBuilder();
      SDQLXMLWriterUtil.Write(XmlWriter.Create(output), construct);
      byte[] buffer = GZipUtil.Zip(output.ToString());
      byte[] bytes = Encoding.UTF8.GetBytes(buffer.Length.ToString());
      stream.Write(bytes, 0, bytes.Length);
      stream.WriteByte((byte) 0);
      stream.Write(buffer, 0, buffer.Length);
    }

    private static void Write(XmlWriter xmlWriter, SDQLConstruct construct)
    {
      xmlWriter.WriteStartDocument();
      xmlWriter.WriteStartElement("sdql");
      switch (construct)
      {
        case SDQLSubscribeRequest _:
          SDQLXMLWriterUtil.Write(xmlWriter, (SDQLSubscribeRequest) construct);
          break;
        case SDQLUpdateDataResumeRequest _:
          SDQLXMLWriterUtil.Write(xmlWriter, (SDQLUpdateDataResumeRequest) construct);
          break;
        case SDQLUnsubscribeRequest _:
          SDQLXMLWriterUtil.Write(xmlWriter, (SDQLUnsubscribeRequest) construct);
          break;
        case SDQLPingResponse _:
          SDQLXMLWriterUtil.Write(xmlWriter, (SDQLPingResponse) construct);
          break;
        default:
          throw new XmlException("Unknown SDQL construct type: " + construct.GetType().Name);
      }
      xmlWriter.WriteEndElement();
      xmlWriter.WriteEndDocument();
      xmlWriter.Flush();
      xmlWriter.Close();
    }

    private static void Write(XmlWriter xmlWriter, SDQLSubscribeRequest construct)
    {
      xmlWriter.WriteStartElement("SubscribeRequest");
      xmlWriter.WriteAttributeString("subscriptionSpecificationName", construct.SubscriptionSpecificationName);
      xmlWriter.WriteEndElement();
    }

    private static void Write(XmlWriter xmlWriter, SDQLUpdateDataResumeRequest construct)
    {
      xmlWriter.WriteStartElement("UpdateDataResumeRequest");
      xmlWriter.WriteAttributeString("subscriptionSpecificationName", construct.SubscriptionSpecificationName);
      xmlWriter.WriteAttributeString("subscriptionChecksum", construct.SubscriptionChecksum);
      xmlWriter.WriteAttributeString("subscriptionId", construct.SubscriptionId);
      xmlWriter.WriteAttributeString("lastBatchUuid", construct.LastBatchUuid);
      xmlWriter.WriteEndElement();
    }

    private static void Write(XmlWriter xmlWriter, SDQLUnsubscribeRequest construct)
    {
      xmlWriter.WriteStartElement("UnsubscribeRequest");
      xmlWriter.WriteAttributeString("subscriptionSpecificationName", construct.SubscriptionSpecificationName);
      xmlWriter.WriteAttributeString("subscriptionId", construct.SubscriptionId);
      xmlWriter.WriteEndElement();
    }

    private static void Write(XmlWriter xmlWriter, SDQLPingResponse construct)
    {
      xmlWriter.WriteStartElement("PingResponse");
      xmlWriter.WriteAttributeString("id", construct.Id);
      xmlWriter.WriteEndElement();
    }
  }
}
