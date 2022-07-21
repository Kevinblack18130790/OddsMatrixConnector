// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLInitialData
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using com.oddsmatrix.sepc.connector.sportsmodel;
using System.Collections.Generic;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLInitialData : SDQLConstruct
  {
    public string BatchId { get; }

    public int BatchesLeft { get; }

    public bool DumpComplete { get; }

    public List<Entity> Entities { get; }

    public SDQLInitialData(
      string batchId,
      int batchesLeft,
      bool dumpComplete,
      List<Entity> entities)
    {
      this.BatchId = batchId;
      this.BatchesLeft = batchesLeft;
      this.DumpComplete = dumpComplete;
      this.Entities = entities;
    }
  }
}
