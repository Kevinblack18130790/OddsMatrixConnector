// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.BettingOffer
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class BettingOffer : Entity, IXmlSerializable
  {
    public long id { get; set; }

    public int version { get; set; }

    public long providerId { get; set; }

    public long sourceId { get; set; }

    public long outcomeId { get; set; }

    public long bettingTypeId { get; set; }

    public long statusId { get; set; }

    public bool? isLive { get; set; }

    public float? odds { get; set; }

    public int? multiplicity { get; set; }

    public float? volume { get; set; }

    public long? volumeCurrencyId { get; set; }

    public string couponKey { get; set; }

    public int slotNum { get; set; }

    public DateTime? lastChangedTime { get; set; }

    public void ReadXml(XmlReader reader)
    {
      this.id = XmlConvert.ToInt64(reader.GetAttribute("id"));
      this.version = XmlConvert.ToInt32(reader.GetAttribute("version"));
      this.providerId = XmlConvert.ToInt64(reader.GetAttribute("providerId"));
      this.sourceId = XmlConvert.ToInt64(reader.GetAttribute("sourceId"));
      this.outcomeId = XmlConvert.ToInt64(reader.GetAttribute("outcomeId"));
      this.bettingTypeId = XmlConvert.ToInt64(reader.GetAttribute("bettingTypeId"));
      this.statusId = XmlConvert.ToInt64(reader.GetAttribute("statusId"));
      if (reader.GetAttribute("isLive") != null)
        this.isLive = new bool?(XmlConvert.ToBoolean(reader.GetAttribute("isLive")));
      if (reader.GetAttribute("odds") != null)
        this.odds = new float?(XmlConvert.ToSingle(reader.GetAttribute("odds")));
      if (reader.GetAttribute("multiplicity") != null)
        this.multiplicity = new int?(XmlConvert.ToInt32(reader.GetAttribute("multiplicity")));
      if (reader.GetAttribute("volume") != null)
        this.volume = new float?(XmlConvert.ToSingle(reader.GetAttribute("volume")));
      if (reader.GetAttribute("volumeCurrencyId") != null)
        this.volumeCurrencyId = new long?(XmlConvert.ToInt64(reader.GetAttribute("volumeCurrencyId")));
      this.couponKey = reader.GetAttribute("couponKey");
      this.slotNum = XmlConvert.ToInt32(reader.GetAttribute("slotNum"));
      if (reader.GetAttribute("lastChangedTime") == null)
        return;
      this.lastChangedTime = new DateTime?(DateTime.Parse(reader.GetAttribute("lastChangedTime")));
    }

    public XmlSchema GetSchema() => (XmlSchema) null;

    public void WriteXml(XmlWriter writer) => throw new NotSupportedException();
  }
}
