// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.BettingTypeUsage
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class BettingTypeUsage : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long bettingTypeId { get; set; }

    public long eventTypeId { get; set; }

    public long sportId { get; set; }

    public long eventPartId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.bettingTypeId = XmlConvert.ToInt64(reader.GetAttribute("bettingTypeId"));
      this.eventTypeId = XmlConvert.ToInt64(reader.GetAttribute("eventTypeId"));
      this.sportId = XmlConvert.ToInt64(reader.GetAttribute("sportId"));
      this.eventPartId = XmlConvert.ToInt64(reader.GetAttribute("eventPartId"));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
