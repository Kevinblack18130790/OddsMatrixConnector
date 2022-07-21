// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Provider
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class Provider : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public string name { get; set; }

    public long locationId { get; set; }

    public string url { get; set; }

    public bool isBookmaker { get; set; }

    public bool isBettingExchange { get; set; }

    public float bettingCommissionVACs { get; set; }

    public bool isLiveOddsApproved { get; set; }

    public bool isNewsSource { get; set; }

    public bool isEnabled { get; set; }

    public string note { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.name = reader.GetAttribute("name");
      this.locationId = XmlConvert.ToInt64(reader.GetAttribute("locationId"));
      this.url = reader.GetAttribute("url");
      this.isBookmaker = XmlConvert.ToBoolean(reader.GetAttribute("isBookmaker"));
      this.isBettingExchange = XmlConvert.ToBoolean(reader.GetAttribute("isBettingExchange"));
      this.bettingCommissionVACs = XmlConvert.ToSingle(reader.GetAttribute("bettingCommissionVACs"));
      this.isLiveOddsApproved = XmlConvert.ToBoolean(reader.GetAttribute("isLiveOddsApproved"));
      this.isNewsSource = XmlConvert.ToBoolean(reader.GetAttribute("isNewsSource"));
      this.isEnabled = XmlConvert.ToBoolean(reader.GetAttribute("isEnabled"));
      this.note = reader.GetAttribute("note");
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
