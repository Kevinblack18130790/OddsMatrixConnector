// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EntityChangeBatch
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EntityChangeBatch
  {
    public long Id { get; }

    public string Uuid { get; }

    public DateTime CreateTime { get; }

    public List<EntityChange> EntityChanges { get; }

    public string SubscriptionId { get; }

    public string SubscriptionChecksum { get; }

    public EntityChangeBatch(
      long id,
      string uuid,
      DateTime createTime,
      List<EntityChange> entityChanges,
      string subscriptionId,
      string subscriptionChecksum)
    {
      this.Id = id;
      this.Uuid = uuid;
      this.CreateTime = createTime;
      this.EntityChanges = entityChanges;
      this.SubscriptionId = subscriptionId;
      this.SubscriptionChecksum = subscriptionChecksum;
    }

    public override string ToString() => string.Format("{0}(id={1},", (object) this.GetType().Name, (object) this.Id) + "uuid=" + this.Uuid + "," + string.Format("createTime={0},", (object) this.CreateTime) + "subscriptionId=" + this.SubscriptionId + ",subscriptionChecksum=" + this.SubscriptionChecksum + "," + string.Format("#entityChanges={0})", (object) (this.EntityChanges == null ? 0 : this.EntityChanges.Count));
  }
}
