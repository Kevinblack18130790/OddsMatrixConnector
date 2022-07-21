// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.ParticipantRelation
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class ParticipantRelation : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public long fromParticipantId { get; set; }

    public long toParticipantId { get; set; }

    public DateTime? startTime { get; set; }

    public DateTime? endTime { get; set; }

    public long? paramParticipantRoleId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.fromParticipantId = XmlConvert.ToInt64(reader.GetAttribute("fromParticipantId"));
      this.toParticipantId = XmlConvert.ToInt64(reader.GetAttribute("toParticipantId"));
      if (reader.GetAttribute("startTime") != null)
        this.startTime = new DateTime?(DateTime.Parse(reader.GetAttribute("startTime")));
      if (reader.GetAttribute("endTime") != null)
        this.endTime = new DateTime?(DateTime.Parse(reader.GetAttribute("endTime")));
      if (reader.GetAttribute("paramParticipantRoleId") == null)
        return;
      this.paramParticipantRoleId = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantRoleId")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
