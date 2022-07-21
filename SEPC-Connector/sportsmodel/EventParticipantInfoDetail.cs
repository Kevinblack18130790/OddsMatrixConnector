// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventParticipantInfoDetail
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventParticipantInfoDetail : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public long eventParticipantInfoId { get; set; }

    public long statusId { get; set; }

    public float? paramFloat1 { get; set; }

    public long? paramParticipantId1 { get; set; }

    public bool? paramBoolean1 { get; set; }

    public string paramString1 { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.eventParticipantInfoId = XmlConvert.ToInt64(reader.GetAttribute("eventParticipantInfoId"));
      this.statusId = XmlConvert.ToInt64(reader.GetAttribute("statusId"));
      if (reader.GetAttribute("paramFloat1") != null)
        this.paramFloat1 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat1")));
      if (reader.GetAttribute("paramParticipantId1") != null)
        this.paramParticipantId1 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId1")));
      if (reader.GetAttribute("paramBoolean1") != null)
        this.paramBoolean1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("paramBoolean1")));
      this.paramString1 = reader.GetAttribute("paramString1");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
