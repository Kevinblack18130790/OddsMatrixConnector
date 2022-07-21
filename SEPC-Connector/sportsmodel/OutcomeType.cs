// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.OutcomeType
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class OutcomeType : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public bool? hasParamFloat1 { get; set; }

    public string paramFloat1Description { get; set; }

    public bool? hasParamFloat2 { get; set; }

    public string paramFloat2Description { get; set; }

    public bool? hasParamFloat3 { get; set; }

    public string paramFloat3Description { get; set; }

    public bool? hasParamBoolean1 { get; set; }

    public string paramBoolean1Description { get; set; }

    public bool? hasParamString1 { get; set; }

    public string paramString1Description { get; set; }

    public string paramString1PossibleValues { get; set; }

    public bool? hasParamParticipantId1 { get; set; }

    public string paramParticipantId1Description { get; set; }

    public bool paramParticipant1MustBePrimary { get; set; }

    public bool paramParticipant1MustBeRoot { get; set; }

    public long? paramParticipant1MustHaveRoleId { get; set; }

    public bool? hasParamParticipantId2 { get; set; }

    public string paramParticipantId2Description { get; set; }

    public bool paramParticipant2MustBePrimary { get; set; }

    public bool paramParticipant2MustBeRoot { get; set; }

    public long? paramParticipant2MustHaveRoleId { get; set; }

    public bool? hasParamParticipantId3 { get; set; }

    public string paramParticipantId3Description { get; set; }

    public bool paramParticipant3MustBePrimary { get; set; }

    public bool paramParticipant3MustBeRoot { get; set; }

    public long? paramParticipant3MustHaveRoleId { get; set; }

    public bool? hasParamEventPartId1 { get; set; }

    public string paramEventPartId1Description { get; set; }

    public bool? hasParamScoringUnitId1 { get; set; }

    public string paramScoringUnitId1Description { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.description = reader.GetAttribute("description");
      if (reader.GetAttribute("hasParamFloat1") != null)
        this.hasParamFloat1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamFloat1")));
      this.paramFloat1Description = reader.GetAttribute("paramFloat1Description");
      if (reader.GetAttribute("hasParamFloat2") != null)
        this.hasParamFloat2 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamFloat2")));
      this.paramFloat2Description = reader.GetAttribute("paramFloat2Description");
      if (reader.GetAttribute("hasParamFloat3") != null)
        this.hasParamFloat3 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamFloat3")));
      this.paramFloat3Description = reader.GetAttribute("paramFloat3Description");
      if (reader.GetAttribute("hasParamBoolean1") != null)
        this.hasParamBoolean1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamBoolean1")));
      this.paramBoolean1Description = reader.GetAttribute("paramBoolean1Description");
      if (reader.GetAttribute("hasParamString1") != null)
        this.hasParamString1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamString1")));
      this.paramString1Description = reader.GetAttribute("paramString1Description");
      this.paramString1PossibleValues = reader.GetAttribute("paramString1PossibleValues");
      if (reader.GetAttribute("hasParamParticipantId1") != null)
        this.hasParamParticipantId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId1")));
      this.paramParticipantId1Description = reader.GetAttribute("paramParticipantId1Description");
      this.paramParticipant1MustBePrimary = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant1MustBePrimary"));
      this.paramParticipant1MustBeRoot = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant1MustBeRoot"));
      if (reader.GetAttribute("paramParticipant1MustHaveRoleId") != null)
        this.paramParticipant1MustHaveRoleId = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipant1MustHaveRoleId")));
      if (reader.GetAttribute("hasParamParticipantId2") != null)
        this.hasParamParticipantId2 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId2")));
      this.paramParticipantId2Description = reader.GetAttribute("paramParticipantId2Description");
      this.paramParticipant2MustBePrimary = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant2MustBePrimary"));
      this.paramParticipant2MustBeRoot = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant2MustBeRoot"));
      if (reader.GetAttribute("paramParticipant2MustHaveRoleId") != null)
        this.paramParticipant2MustHaveRoleId = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipant2MustHaveRoleId")));
      if (reader.GetAttribute("hasParamParticipantId3") != null)
        this.hasParamParticipantId3 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId3")));
      this.paramParticipantId3Description = reader.GetAttribute("paramParticipantId3Description");
      this.paramParticipant3MustBePrimary = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant3MustBePrimary"));
      this.paramParticipant3MustBeRoot = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipant3MustBeRoot"));
      if (reader.GetAttribute("paramParticipant3MustHaveRoleId") != null)
        this.paramParticipant3MustHaveRoleId = new long?(XmlConvert.ToInt64(reader.GetAttribute("paramParticipant3MustHaveRoleId")));
      if (reader.GetAttribute("hasParamEventPartId1") != null)
        this.hasParamEventPartId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamEventPartId1")));
      this.paramEventPartId1Description = reader.GetAttribute("paramEventPartId1Description");
      if (reader.GetAttribute("hasParamScoringUnitId1") != null)
        this.hasParamScoringUnitId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamScoringUnitId1")));
      this.paramScoringUnitId1Description = reader.GetAttribute("paramScoringUnitId1Description");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
