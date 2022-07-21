// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Outcome
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Outcome : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public bool isNegation { get; set; }

    public long statusId { get; set; }

    public long eventId { get; set; }

    public long eventPartId { get; set; }

    public float? paramFloat1 { get; set; }

    public float? paramFloat2 { get; set; }

    public float? paramFloat3 { get; set; }

    public bool? paramBoolean1 { get; set; }

    public string paramString1 { get; set; }

    public long? paramParticipantId1 { get; set; }

    public long? paramParticipantId2 { get; set; }

    public long? paramParticipantId3 { get; set; }

    public long? paramEventPartId1 { get; set; }

    public long? paramScoringUnitId1 { get; set; }

    public string code { get; set; }

    public string name { get; set; }

    public bool? settlementRequired { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.isNegation = XmlConvert.ToBoolean(reader.GetAttribute("isNegation"));
      this.statusId = XmlConvert.ToInt64(reader.GetAttribute("statusId"));
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      this.eventPartId = XmlConvert.ToInt64(reader.GetAttribute("eventPartId"));
      if (reader.GetAttribute("paramFloat1") != null)
        this.paramFloat1 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat1")));
      if (reader.GetAttribute("paramFloat2") != null)
        this.paramFloat2 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat2")));
      if (reader.GetAttribute("paramFloat3") != null)
        this.paramFloat3 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat3")));
      if (reader.GetAttribute("paramBoolean1") != null)
        this.paramBoolean1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("paramBoolean1")));
      this.paramString1 = reader.GetAttribute("paramString1");
      if (reader.GetAttribute("paramParticipantId1") != null)
        this.paramParticipantId1 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId1")));
      if (reader.GetAttribute("paramParticipantId2") != null)
        this.paramParticipantId2 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId2")));
      if (reader.GetAttribute("paramParticipantId3") != null)
        this.paramParticipantId3 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId3")));
      if (reader.GetAttribute("paramEventPartId1") != null)
        this.paramEventPartId1 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramEventPartId1")));
      if (reader.GetAttribute("paramScoringUnitId1") != null)
        this.paramScoringUnitId1 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramScoringUnitId1")));
      this.code = reader.GetAttribute("code");
      this.name = reader.GetAttribute("name");
      if (reader.GetAttribute("settlementRequired") == null)
        return;
      this.settlementRequired = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("settlementRequired")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
