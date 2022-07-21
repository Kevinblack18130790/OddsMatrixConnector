// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventInfoType
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using log4net;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventInfoType : Entity, IXmlSerializable
  {
    protected readonly ILog LOG = LogManager.GetLogger(typeof (EventInfoType));

    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public bool? hasParamFloat1 { get; set; }

    public string paramFloat1Description { get; set; }

    public bool? hasParamFloat2 { get; set; }

    public string paramFloat2Description { get; set; }

    public bool? hasParamParticipantId1 { get; set; }

    public string paramParticipantId1Description { get; set; }

    public bool? hasParamParticipantId2 { get; set; }

    public string paramParticipantId2Description { get; set; }

    public bool? hasParamEventPartId1 { get; set; }

    public string paramEventPartId1Description { get; set; }

    public bool? hasParamString1 { get; set; }

    public string paramString1Description { get; set; }

    public string paramString1PossibleValues { get; set; }

    public bool? hasParamBoolean1 { get; set; }

    public string paramBoolean1Description { get; set; }

    public bool? hasParamEventStatusId1 { get; set; }

    public string paramEventStatusId1Description { get; set; }

    public bool? hasParamTime1 { get; set; }

    public string paramTime1Description { get; set; }

    public bool paramParticipantIdsMustBeOrdered { get; set; }

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
      if (reader.GetAttribute("hasParamParticipantId1") != null)
        this.hasParamParticipantId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId1")));
      this.paramParticipantId1Description = reader.GetAttribute("paramParticipantId1Description");
      if (reader.GetAttribute("hasParamParticipantId2") != null)
        this.hasParamParticipantId2 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId2")));
      this.paramParticipantId2Description = reader.GetAttribute("paramParticipantId2Description");
      if (reader.GetAttribute("hasParamEventPartId1") != null)
        this.hasParamEventPartId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamEventPartId1")));
      this.paramEventPartId1Description = reader.GetAttribute("paramEventPartId1Description");
      if (reader.GetAttribute("hasParamString1") != null)
        this.hasParamString1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamString1")));
      this.paramString1Description = reader.GetAttribute("paramString1Description");
      this.paramString1PossibleValues = reader.GetAttribute("paramString1PossibleValues");
      if (reader.GetAttribute("hasParamBoolean1") != null)
        this.hasParamBoolean1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamBoolean1")));
      this.paramBoolean1Description = reader.GetAttribute("paramBoolean1Description");
      if (reader.GetAttribute("hasParamEventStatusId1") != null)
        this.hasParamEventStatusId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamEventStatusId1")));
      this.paramEventStatusId1Description = reader.GetAttribute("paramEventStatusId1Description");
      if (reader.GetAttribute("hasParamTime1") != null)
        this.hasParamTime1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamTime1")));
      this.paramTime1Description = reader.GetAttribute("paramTime1Description");
      this.paramParticipantIdsMustBeOrdered = XmlConvert.ToBoolean(reader.GetAttribute("paramParticipantIdsMustBeOrdered"));
      if (reader.GetAttribute("hasParamScoringUnitId1") != null)
        this.hasParamScoringUnitId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamScoringUnitId1")));
      this.paramScoringUnitId1Description = reader.GetAttribute("paramScoringUnitId1Description");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
