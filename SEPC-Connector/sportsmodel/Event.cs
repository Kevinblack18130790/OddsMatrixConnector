// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Event
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Event : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long typeId { get; set; }

    public bool isComplete { get; set; }

    public long sportId { get; set; }

    public long? templateId { get; set; }

    public long? categoryId { get; set; }

    public long? promotionId { get; set; }

    public long? parentId { get; set; }

    public long? parentPartId { get; set; }

    public string name { get; set; }

    public DateTime? startTime { get; set; }

    public DateTime? endTime { get; set; }

    public long deleteTimeOffset { get; set; }

    public long? venueId { get; set; }

    public long statusId { get; set; }

    public bool hasLiveStatus { get; set; }

    public long rootPartId { get; set; }

    public long? currentPartId { get; set; }

    public string url { get; set; }

    public int? popularity { get; set; }

    public string note { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.typeId = XmlConvert.ToInt64(reader.GetAttribute("typeId"));
      this.isComplete = XmlConvert.ToBoolean(reader.GetAttribute("isComplete"));
      this.sportId = XmlConvert.ToInt64(reader.GetAttribute("sportId"));
      if (reader.GetAttribute("templateId") != null)
        this.templateId = new long?(XmlConvert.ToInt64(reader.GetAttribute("templateId")));
      if (reader.GetAttribute("categoryId") != null)
        this.categoryId = new long?(XmlConvert.ToInt64(reader.GetAttribute("categoryId")));
      if (reader.GetAttribute("promotionId") != null)
        this.promotionId = new long?(XmlConvert.ToInt64(reader.GetAttribute("promotionId")));
      if (reader.GetAttribute("parentId") != null)
        this.parentId = new long?(XmlConvert.ToInt64(reader.GetAttribute("parentId")));
      if (reader.GetAttribute("parentPartId") != null)
        this.parentPartId = new long?(XmlConvert.ToInt64(reader.GetAttribute("parentPartId")));
      this.name = reader.GetAttribute("name");
      if (reader.GetAttribute("startTime") != null)
        this.startTime = new DateTime?(DateTime.Parse(reader.GetAttribute("startTime")));
      if (reader.GetAttribute("endTime") != null)
        this.endTime = new DateTime?(DateTime.Parse(reader.GetAttribute("endTime")));
      this.deleteTimeOffset = XmlConvert.ToInt64(reader.GetAttribute("deleteTimeOffset"));
      if (reader.GetAttribute("venueId") != null)
        this.venueId = new long?(XmlConvert.ToInt64(reader.GetAttribute("venueId")));
      this.statusId = XmlConvert.ToInt64(reader.GetAttribute("statusId"));
      this.hasLiveStatus = XmlConvert.ToBoolean(reader.GetAttribute("hasLiveStatus"));
      this.rootPartId = XmlConvert.ToInt64(reader.GetAttribute("rootPartId"));
      if (reader.GetAttribute("currentPartId") != null)
        this.currentPartId = new long?(XmlConvert.ToInt64(reader.GetAttribute("currentPartId")));
      this.url = reader.GetAttribute("url");
      if (reader.GetAttribute("popularity") != null)
        this.popularity = new int?(XmlConvert.ToInt32(reader.GetAttribute("popularity")));
      this.note = reader.GetAttribute("note");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
