// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Market
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Market : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public long eventId { get; set; }

    public long eventPartId { get; set; }

    public long bettingTypeId { get; set; }

    public long? scoringUnitId { get; set; }

    public string discriminator { get; set; }

    public int? numberOfOutcomes { get; set; }

    public bool isComplete { get; set; }

    public bool isClosed { get; set; }

    public float? paramFloat1 { get; set; }

    public float? paramFloat2 { get; set; }

    public float? paramFloat3 { get; set; }

    public string paramString1 { get; set; }

    public long? paramParticipantId1 { get; set; }

    public long? paramParticipantId2 { get; set; }

    public long? paramParticipantId3 { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.eventId = XmlConvert.ToInt64(reader.GetAttribute("eventId"));
      this.eventPartId = XmlConvert.ToInt64(reader.GetAttribute("eventPartId"));
      this.bettingTypeId = XmlConvert.ToInt64(reader.GetAttribute("bettingTypeId"));
      if (reader.GetAttribute("scoringUnitId") != null)
        this.scoringUnitId = new long?(XmlConvert.ToInt64(reader.GetAttribute("scoringUnitId")));
      this.discriminator = reader.GetAttribute("discriminator");
      if (reader.GetAttribute("numberOfOutcomes") != null)
        this.numberOfOutcomes = new int?(XmlConvert.ToInt32(reader.GetAttribute("numberOfOutcomes")));
      this.isComplete = XmlConvert.ToBoolean(reader.GetAttribute("isComplete"));
      this.isClosed = XmlConvert.ToBoolean(reader.GetAttribute("isClosed"));
      if (reader.GetAttribute("paramFloat1") != null)
        this.paramFloat1 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat1")));
      if (reader.GetAttribute("paramFloat2") != null)
        this.paramFloat2 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat2")));
      if (reader.GetAttribute("paramFloat3") != null)
        this.paramFloat3 = new float?(XmlConvert.ToSingle(reader.GetAttribute("paramFloat3")));
      this.paramString1 = reader.GetAttribute("paramString1");
      if (reader.GetAttribute("paramParticipantId1") != null)
        this.paramParticipantId1 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId1")));
      if (reader.GetAttribute("paramParticipantId2") != null)
        this.paramParticipantId2 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId2")));
      if (reader.GetAttribute("paramParticipantId3") == null)
        return;
      this.paramParticipantId3 = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipantId3")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
