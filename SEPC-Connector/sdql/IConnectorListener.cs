// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.IConnectorListener
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public interface IConnectorListener
  {
    void NotifyInitialDump(List<Entity> initialDump);

    void NotifyEntityUpdates(EntityChangeBatch entityChangeBatch);
  }
}
