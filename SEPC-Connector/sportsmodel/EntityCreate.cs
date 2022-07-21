// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EntityCreate
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EntityCreate : EntityChange
  {
    public Entity Entity { get; }

    public EntityCreate(Entity entity) => this.Entity = entity;

    public override Type GetEntityType() => this.Entity.GetType();
  }
}
