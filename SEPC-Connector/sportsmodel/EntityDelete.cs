// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EntityDelete
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EntityDelete : EntityChange
  {
    private Type EntityType { get; }

    public long EntityId { get; }

    public EntityDelete(Type type, long entityId)
    {
      this.EntityType = type;
      this.EntityId = entityId;
    }

    public override Type GetEntityType() => this.EntityType;
  }
}
