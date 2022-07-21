// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventParticipantInfo
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventParticipantInfo : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public long eventId { get; set; }

    public long providerId { get; set; }

    public long statusId { get; set; }

    public long eventPartId { get; set; }

    public long participantId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      this.providerId = XmlConvert.ToInt64(reader.GetAttribute("providerId"));
      this.statusId = XmlConvert.ToInt64(reader.GetAttribute("statusId"));
      this.eventPartId = XmlConvert.ToInt64(reader.GetAttribute("eventPartId"));
      this.participantId = XmlConvert.ToInt64(reader.GetAttribute("participantId"));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
