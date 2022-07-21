// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLUpdateDataResumeRequest
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLUpdateDataResumeRequest : SDQLConstruct
  {
    public string SubscriptionSpecificationName { get; }

    public string SubscriptionId { get; }

    public string SubscriptionChecksum { get; }

    public string LastBatchUuid { get; }

    public SDQLUpdateDataResumeRequest(
      string subscriptionSpecificationName,
      string subscriptionId,
      string subscriptionChecksum,
      string lastBatchUuid)
    {
      this.SubscriptionSpecificationName = subscriptionSpecificationName;
      this.SubscriptionId = subscriptionId;
      this.SubscriptionChecksum = subscriptionChecksum;
      this.LastBatchUuid = lastBatchUuid;
    }

    public override string ToString() => this.GetType().Name + "(subscriptionSpecificationName=" + this.SubscriptionSpecificationName + ",subscriptionId=" + this.SubscriptionId + ",subscriptionChecksum=" + this.SubscriptionChecksum + ",lastBatchUuid=" + this.LastBatchUuid + ")";
  }
}
