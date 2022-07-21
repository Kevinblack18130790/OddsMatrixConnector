﻿// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.OutcomeTypeBettingTypeRelation
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class OutcomeTypeBettingTypeRelation : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long outcomeTypeId { get; set; }

    public long bettingTypeId { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.outcomeTypeId = XmlConvert.ToInt64(reader.GetAttribute("outcomeTypeId"));
      this.bettingTypeId = XmlConvert.ToInt64(reader.GetAttribute("bettingTypeId"));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
