// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.EntityUpdate
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public class EntityUpdate : EntityChange
  {
    public Type EntityType { get; }

    public long EntityId { get; }

    public List<string> PropertyNames { get; }

    public List<object> PropertyValues { get; }

    public EntityUpdate(
      Type type,
      long entityId,
      List<string> propertyNames,
      List<object> propertyValues)
    {
      this.EntityType = type;
      this.EntityId = entityId;
      this.PropertyNames = propertyNames;
      this.PropertyValues = propertyValues;
    }

    public override Type GetEntityType() => this.EntityType;
  }
}
