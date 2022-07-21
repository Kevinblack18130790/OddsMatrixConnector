// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLPingResponse
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLPingResponse : SDQLConstruct
  {
    public string Id;

    public SDQLPingResponse(string id) => this.Id = id;

    public override string ToString() => this.GetType().Name + "(id=" + this.Id + ")";
  }
}
