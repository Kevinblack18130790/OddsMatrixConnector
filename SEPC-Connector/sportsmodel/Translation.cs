﻿// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Translation
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Translation : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public string name { get; set; }

    public long entityId { get; set; }

    public long entityTypeId { get; set; }

    public long languageId { get; set; }

    public DateTime? lastChangedDate { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.name = reader.GetAttribute("name");
      this.entityId = XmlConvert.ToInt64(reader.GetAttribute("entityId"));
      this.entityTypeId = XmlConvert.ToInt64(reader.GetAttribute("entityTypeId"));
      this.languageId = XmlConvert.ToInt64(reader.GetAttribute("languageId"));
      if (reader.GetAttribute("lastChangedDate") == null)
        return;
      this.lastChangedDate = new DateTime?(DateTime.Parse(reader.GetAttribute("lastChangedDate")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}