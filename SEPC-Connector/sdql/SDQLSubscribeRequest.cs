// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLSubscribeRequest
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLSubscribeRequest : SDQLConstruct
  {
    public string SubscriptionSpecificationName { get; }

    public SDQLSubscribeRequest(string subscriptionSpecificationName) => this.SubscriptionSpecificationName = subscriptionSpecificationName;

    public override bool Equals(object obj) => obj is SDQLSubscribeRequest subscribeRequest && this.SubscriptionSpecificationName == subscribeRequest.SubscriptionSpecificationName;

    public override int GetHashCode() => 2023521010 + EqualityComparer<string>.Default.GetHashCode(this.SubscriptionSpecificationName);

    public override string ToString() => this.GetType().Name + "(subscriptionSpecificationName=" + this.SubscriptionSpecificationName + ")";
  }
}
