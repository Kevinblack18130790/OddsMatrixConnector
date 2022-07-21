// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EventTemplate
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EventTemplate : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public long eventTypeId { get; set; }

    public long sportId { get; set; }

    public long? categoryId { get; set; }

    public string url { get; set; }

    public long? venueId { get; set; }

    public long? rootPartId { get; set; }

    public string note { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.eventTypeId = XmlConvert.ToInt64(reader.GetAttribute("eventTypeId"));
      this.sportId = XmlConvert.ToInt64(reader.GetAttribute("sportId"));
      if (reader.GetAttribute("categoryId") != null)
        this.categoryId = new long?(XmlConvert.ToInt64(reader.GetAttribute("categoryId")));
      this.url = reader.GetAttribute("url");
      if (reader.GetAttribute("venueId") != null)
        this.venueId = new long?(XmlConvert.ToInt64(reader.GetAttribute("venueId")));
      if (reader.GetAttribute("rootPartId") != null)
        this.rootPartId = new long?(XmlConvert.ToInt64(reader.GetAttribute("rootPartId")));
      this.note = reader.GetAttribute("note");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
