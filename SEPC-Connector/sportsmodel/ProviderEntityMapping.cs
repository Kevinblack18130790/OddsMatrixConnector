// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.ProviderEntityMapping
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class ProviderEntityMapping : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long providerId { get; set; }

    public string providerEntityTypeId { get; set; }

    public string providerEntityId { get; set; }

    public long entityTypeId { get; set; }

    public long entityId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.providerId = XmlConvert.ToInt64(reader.GetAttribute("providerId"));
      this.providerEntityTypeId = reader.GetAttribute("providerEntityTypeId");
      this.providerEntityId = reader.GetAttribute("providerEntityId");
      this.entityTypeId = XmlConvert.ToInt64(reader.GetAttribute("entityTypeId"));
      this.entityId = XmlConvert.ToInt64(reader.GetAttribute("entityId"));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
