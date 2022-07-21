// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.ProviderEventRelation
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class ProviderEventRelation : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long providerId { get; set; }

    public long eventId { get; set; }

    public DateTime? startTime { get; set; }

    public DateTime? endTime { get; set; }

    public int timeQualityRank { get; set; }

    public bool offersLiveOdds { get; set; }

    public bool offersLiveTV { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.providerId = XmlConvert.ToInt64(reader.GetAttribute("providerId"));
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      if (reader.GetAttribute("startTime") != null)
        this.startTime = new DateTime?(DateTime.Parse(reader.GetAttribute("startTime")));
      if (reader.GetAttribute("endTime") != null)
        this.endTime = new DateTime?(DateTime.Parse(reader.GetAttribute("endTime")));
      this.timeQualityRank = XmlConvert.ToInt32(reader.GetAttribute("timeQualityRank"));
      this.offersLiveOdds = XmlConvert.ToBoolean(reader.GetAttribute("offersLiveOdds"));
      this.offersLiveTV = XmlConvert.ToBoolean(reader.GetAttribute("offersLiveTV"));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
