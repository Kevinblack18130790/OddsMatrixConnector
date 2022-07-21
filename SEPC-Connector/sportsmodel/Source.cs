// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Source
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Source : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long collectorId { get; set; }

    public long providerId { get; set; }

    public string sourceKey { get; set; }

    public DateTime? lastCollectedTime { get; set; }

    public DateTime? lastUpdatedTime { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.collectorId = XmlConvert.ToInt64(reader.GetAttribute("collectorId"));
      this.providerId = XmlConvert.ToInt64(reader.GetAttribute("providerId"));
      this.sourceKey = reader.GetAttribute("sourceKey");
      if (reader.GetAttribute("lastCollectedTime") != null)
        this.lastCollectedTime = new DateTime?(DateTime.Parse(reader.GetAttribute("lastCollectedTime")));
      if (reader.GetAttribute("lastUpdatedTime") == null)
        return;
      this.lastUpdatedTime = new DateTime?(DateTime.Parse(reader.GetAttribute("lastUpdatedTime")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
