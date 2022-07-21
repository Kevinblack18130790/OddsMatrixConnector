// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLUpdateData
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using System;
using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLUpdateData : SDQLConstruct
  {
    public long BatchId { get; }

    public string BatchUuid { get; }

    public DateTime CreateTime { get; }

    public List<EntityChange> EntityChanges { get; }

    public SDQLUpdateData(
      long batchId,
      string batchUuid,
      DateTime createTime,
      List<EntityChange> entityChanges)
    {
      this.BatchId = batchId;
      this.BatchUuid = batchUuid;
      this.CreateTime = createTime;
      this.EntityChanges = entityChanges;
    }

    public override string ToString() => string.Format("{0}(batchId={1},batchUuid={2},createTime={3},#entityChanges={4})", (object) this.GetType().Name, (object) this.BatchId, (object) this.BatchUuid, (object) this.CreateTime, (object) (this.EntityChanges == null ? 0 : this.EntityChanges.Count));
  }
}
