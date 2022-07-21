// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventParticipantRestriction
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventParticipantRestriction : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long eventId { get; set; }

    public long participantTypeId { get; set; }

    public bool? participantIsMale { get; set; }

    public int? participantMinAge { get; set; }

    public int? participantMaxAge { get; set; }

    public long? participantPartOfLocationId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      this.participantTypeId = XmlConvert.ToInt64(reader.GetAttribute("participantTypeId"));
      if (reader.GetAttribute("participantIsMale") != null)
        this.participantIsMale = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("participantIsMale")));
      if (reader.GetAttribute("participantMinAge") != null)
        this.participantMinAge = new int?(XmlConvert.ToInt32(reader.GetAttribute("participantMinAge")));
      if (reader.GetAttribute("participantMaxAge") != null)
        this.participantMaxAge = new int?(XmlConvert.ToInt32(reader.GetAttribute("participantMaxAge")));
      if (reader.GetAttribute("participantPartOfLocationId") == null)
        return;
      this.participantPartOfLocationId = new long?(XmlConvert.ToInt64(reader.GetAttribute("participantPartOfLocationId")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
