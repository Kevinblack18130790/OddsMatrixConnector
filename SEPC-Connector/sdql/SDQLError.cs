// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLError
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLError : SDQLConstruct
  {
    public int Code { get; }

    public string Message { get; }

    public SDQLError(int code, string message)
    {
      this.Code = code;
      this.Message = message;
    }

    public override string ToString() => string.Format("{0}(code={1},message={2})", (object) this.GetType().Name, (object) this.Code, (object) this.Message);
  }
}
