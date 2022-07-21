// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventParticipantRelation
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventParticipantRelation : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long eventId { get; set; }

    public long eventPartId { get; set; }

    public long participantId { get; set; }

    public long participantRoleId { get; set; }

    public long? parentParticipantId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      this.eventPartId = XmlConvert.ToInt64(reader.GetAttribute("eventPartId"));
      this.participantId = XmlConvert.ToInt64(reader.GetAttribute("participantId"));
      this.participantRoleId = XmlConvert.ToInt64(reader.GetAttribute("participantRoleId"));
      if (reader.GetAttribute("parentParticipantId") == null)
        return;
      this.parentParticipantId = new long?(XmlConvert.ToInt64(reader.GetAttribute("parentParticipantId")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
