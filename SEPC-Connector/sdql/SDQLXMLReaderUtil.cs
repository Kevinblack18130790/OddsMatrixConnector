// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLXMLReaderUtil
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using com.oddsmatrix.sepc.connector.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace com.oddsmatrix.sepc.connector.sdql
{
    internal static class SDQLXMLReaderUtil
    {
        internal static SDQLConstruct ReadPDUFromPushStream(NetworkStream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            int num;
            while ((num = stream.ReadByte()) != 0)
                memoryStream.WriteByte((byte)num);
            int length = int.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
            memoryStream.Close();
            byte[] numArray = new byte[length];
            int offset = 0;
            while (offset != length)
                offset += stream.Read(numArray, offset, length - offset);
            return SDQLXMLReaderUtil.ReadFromPushStream(GZipUtil.Unzip(numArray));
        }

        private static SDQLConstruct ReadFromPushStream(string message)
        {
            if (!Directory.Exists("Log3"))
            {
                Directory.CreateDirectory("Log3");
            }
            if (message.Contains("175672166917918720"))
            {
                File.AppendAllText($"Log3\\{DateTime.Now:yyy_MM_dd_hh_mm_ss_fffff}.xml", message);
            }
            XmlReader xmlReader = XmlReader.Create((TextReader)new StringReader(message));
            int content = (int)xmlReader.MoveToContent();
            xmlReader.ReadStartElement("sdql");
            if (xmlReader.NodeType == XmlNodeType.EndElement)
            {
                xmlReader.Close();
                return (SDQLConstruct)null;
            }
            string localName = xmlReader.LocalName;
            SDQLConstruct sdqlConstruct;
            if (!(localName == "SubscribeResponse"))
            {
                if (!(localName == "UnsubscribeResponse"))
                {
                    if (!(localName == "PingRequest"))
                    {
                        if (!(localName == "error"))
                        {
                            if (!(localName == "InitialData"))
                            {
                                if (localName == "UpdateData")
                                {
                                    sdqlConstruct = SDQLXMLReaderUtil.ReadSDQLUpdateData(xmlReader);
                                }
                                else
                                {
                                    xmlReader.Close();
                                    throw new XmlException("Unknown SDQL construct name: " + localName);
                                }
                            }
                            else
                                sdqlConstruct = (SDQLConstruct)SDQLXMLReaderUtil.ReadSDQLInitialData(xmlReader);
                        }
                        else
                            sdqlConstruct = (SDQLConstruct)SDQLXMLReaderUtil.ReadSDQLError(xmlReader);
                    }
                    else
                        sdqlConstruct = (SDQLConstruct)SDQLXMLReaderUtil.ReadSDQLPingRequest(xmlReader);
                }
                else
                    sdqlConstruct = (SDQLConstruct)SDQLXMLReaderUtil.ReadSDQLUnsubscribeResponse(xmlReader);
            }
            else
                sdqlConstruct = (SDQLConstruct)SDQLXMLReaderUtil.ReadSDQLSubscribeResponse(xmlReader);
            xmlReader.ReadEndElement();
            xmlReader.Close();
            return sdqlConstruct;
        }

        private static SDQLPingRequest ReadSDQLPingRequest(XmlReader xmlReader)
        {
            string attribute = xmlReader.GetAttribute("id");
            xmlReader.Read();
            return new SDQLPingRequest(attribute);
        }

        private static SDQLSubscribeResponse ReadSDQLSubscribeResponse(
          XmlReader xmlReader)
        {
            string attribute1 = xmlReader.GetAttribute("subscriptionId");
            string attribute2 = xmlReader.GetAttribute("subscriptionChecksum");
            xmlReader.Read();
            string subscriptionChecksum = attribute2;
            return new SDQLSubscribeResponse(attribute1, subscriptionChecksum);
        }

        private static SDQLUnsubscribeResponse ReadSDQLUnsubscribeResponse(
          XmlReader xmlReader)
        {
            string attribute1 = xmlReader.GetAttribute("id");
            string attribute2 = xmlReader.GetAttribute("message");
            xmlReader.Read();
            return new SDQLUnsubscribeResponse(Convert.ToInt32(attribute1), attribute2);
        }

        private static SDQLError ReadSDQLError(XmlReader xmlReader)
        {
            string attribute1 = xmlReader.GetAttribute("code");
            string attribute2 = xmlReader.GetAttribute("message");
            xmlReader.Read();
            return new SDQLError(Convert.ToInt32(attribute1), attribute2);
        }

        private static SDQLInitialData ReadSDQLInitialData(XmlReader xmlReader)
        {
            string attribute = xmlReader.GetAttribute("batchId");
            int int32 = Convert.ToInt32(xmlReader.GetAttribute("batchesLeft"));
            bool boolean = Convert.ToBoolean(xmlReader.GetAttribute("dumpComplete"));
            List<Entity> entities = new List<Entity>();
            string name = "entities";
            xmlReader.Read();
            xmlReader.ReadStartElement(name);
            while (!xmlReader.LocalName.Equals(name) || xmlReader.NodeType != XmlNodeType.EndElement)
            {
                Entity entity = SDQLEntityDeserializer.Deserialize(xmlReader.LocalName, xmlReader.ReadSubtree());
                if (entity != null)
                    entities.Add(entity);
                xmlReader.Read();
            }
            xmlReader.ReadEndElement();
            return new SDQLInitialData(attribute, int32, boolean, entities);
        }

        private static SDQLConstruct ReadSDQLUpdateData(XmlReader xmlReader)
        {
            long int64_1 = Convert.ToInt64(xmlReader.GetAttribute("batchId"));
            string attribute1 = xmlReader.GetAttribute("batchUuid");
            DateTime createTime = DateTime.Parse(xmlReader.GetAttribute("createdTime"));
            List<EntityChange> entityChanges = new List<EntityChange>();
            xmlReader.Read();
            while (!"UpdateData".Equals(xmlReader.LocalName) || xmlReader.NodeType != XmlNodeType.EndElement)
            {
                string attribute2 = xmlReader.GetAttribute("type");
                Type entityType = SDQLEntityDeserializer.GetEntityType(xmlReader.LocalName);
                if (!(attribute2 == "create"))
                {
                    if (!(attribute2 == "update"))
                    {
                        if (!(attribute2 == "delete"))
                            throw new XmlException("Unexpected change type: " + attribute2);
                        long int64_2 = Convert.ToInt64(xmlReader.GetAttribute("id"));
                        entityChanges.Add((EntityChange)new EntityDelete(entityType, int64_2));
                    }
                    else
                    {
                        long int64_3 = Convert.ToInt64(xmlReader.GetAttribute("id"));
                        List<string> propertyNames = new List<string>();
                        List<object> propertyValues = new List<object>();
                        for (int i = 2; i < xmlReader.AttributeCount; ++i)
                        {
                            xmlReader.MoveToAttribute(i);
                            string name = xmlReader.Name;
                            object obj = (object)xmlReader.Value;
                            propertyNames.Add(name);
                            propertyValues.Add(obj);
                        }
                        xmlReader.MoveToElement();
                        entityChanges.Add((EntityChange)new EntityUpdate(entityType, int64_3, propertyNames, propertyValues));
                    }
                }
                else
                {
                    Entity entity = SDQLEntityDeserializer.Deserialize(xmlReader.LocalName, xmlReader.ReadSubtree());
                    if (entity != null)
                        entityChanges.Add((EntityChange)new EntityCreate(entity));
                }
                xmlReader.Read();
            }
            xmlReader.ReadEndElement();
            return (SDQLConstruct)new SDQLUpdateData(int64_1, attribute1, createTime, entityChanges);
        }
    }
}
