// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLUnsubscribeRequest
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLUnsubscribeRequest : SDQLConstruct
  {
    public string SubscriptionSpecificationName { get; }

    public string SubscriptionId { get; }

    public SDQLUnsubscribeRequest(string subscriptionSpecificationName, string subscriptionId)
    {
      this.SubscriptionSpecificationName = subscriptionSpecificationName;
      this.SubscriptionId = subscriptionId;
    }

    public override bool Equals(object obj) => obj is SDQLUnsubscribeRequest unsubscribeRequest && this.SubscriptionSpecificationName == unsubscribeRequest.SubscriptionSpecificationName && this.SubscriptionId == unsubscribeRequest.SubscriptionId;

        //public override int GetHashCode() => (1790391819 * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.SubscriptionSpecificationName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.SubscriptionId);
        public override int GetHashCode() => (EqualityComparer<string>.Default.GetHashCode(this.SubscriptionSpecificationName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.SubscriptionId);

        public override string ToString() => this.GetType().Name + "(subscriptionSpecificationName=" + this.SubscriptionSpecificationName + ",subscriptionId=" + this.SubscriptionId + ")";
  }
}
