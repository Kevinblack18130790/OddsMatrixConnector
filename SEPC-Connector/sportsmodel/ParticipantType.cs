// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.ParticipantType
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class ParticipantType : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public bool isIndividual { get; set; }

    public bool? hasName { get; set; }

    public bool? hasFirstName { get; set; }

    public bool? hasLastName { get; set; }

    public bool? hasIsMale { get; set; }

    public bool? hasBirthTime { get; set; }

    public bool? hasCountryId { get; set; }

    public bool? hasRetirementTime { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.description = reader.GetAttribute("description");
      this.isIndividual = XmlConvert.ToBoolean(reader.GetAttribute("isIndividual"));
      if (reader.GetAttribute("hasName") != null)
        this.hasName = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasName")));
      if (reader.GetAttribute("hasFirstName") != null)
        this.hasFirstName = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasFirstName")));
      if (reader.GetAttribute("hasLastName") != null)
        this.hasLastName = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasLastName")));
      if (reader.GetAttribute("hasIsMale") != null)
        this.hasIsMale = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasIsMale")));
      if (reader.GetAttribute("hasBirthTime") != null)
        this.hasBirthTime = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasBirthTime")));
      if (reader.GetAttribute("hasCountryId") != null)
        this.hasCountryId = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasCountryId")));
      if (reader.GetAttribute("hasRetirementTime") == null)
        return;
      this.hasRetirementTime = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("hasRetirementTime")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
