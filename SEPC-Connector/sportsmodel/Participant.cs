// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Participant
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Participant : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public string name { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

    public bool? isMale { get; set; }

    public DateTime? birthTime { get; set; }

    public long? countryId { get; set; }

    public string url { get; set; }

    public string logoUrl { get; set; }

    public DateTime? retirementTime { get; set; }

    public string note { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.name = reader.GetAttribute("name");
      this.firstName = reader.GetAttribute("firstName");
      this.lastName = reader.GetAttribute("lastName");
      if (reader.GetAttribute("isMale") != null)
        this.isMale = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("isMale")));
      if (reader.GetAttribute("birthTime") != null)
        this.birthTime = new DateTime?(DateTime.Parse(reader.GetAttribute("birthTime")));
      if (reader.GetAttribute("countryId") != null)
        this.countryId = new long?(XmlConvert.ToInt64(reader.GetAttribute("countryId")));
      this.url = reader.GetAttribute("url");
      this.logoUrl = reader.GetAttribute("logoUrl");
      if (reader.GetAttribute("retirementTime") != null)
        this.retirementTime = new DateTime?(DateTime.Parse(reader.GetAttribute("retirementTime")));
      this.note = reader.GetAttribute("note");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
