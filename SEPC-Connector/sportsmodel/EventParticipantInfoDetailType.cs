// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventParticipantInfoDetailType
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventParticipantInfoDetailType : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public bool? hasParamFloat1 { get; set; }

    public string paramFloat1Description { get; set; }

    public bool? hasParamParticipantId1 { get; set; }

    public string paramParticipantId1Description { get; set; }

    public bool? hasParamBoolean1 { get; set; }

    public string paramBoolean1Description { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.description = reader.GetAttribute("description");
      if (reader.GetAttribute("hasParamFloat1") != null)
        this.hasParamFloat1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamFloat1")));
      this.paramFloat1Description = reader.GetAttribute("paramFloat1Description");
      if (reader.GetAttribute("hasParamParticipantId1") != null)
        this.hasParamParticipantId1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamParticipantId1")));
      this.paramParticipantId1Description = reader.GetAttribute("paramParticipantId1Description");
      if (reader.GetAttribute("hasParamBoolean1") != null)
        this.hasParamBoolean1 = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasParamBoolean1")));
      this.paramBoolean1Description = reader.GetAttribute("paramBoolean1Description");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
