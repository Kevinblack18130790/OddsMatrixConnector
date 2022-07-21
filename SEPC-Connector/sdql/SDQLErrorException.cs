// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sdql.SDQLErrorException
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;

namespace com.oddsmatrix.sepc.connector.sdql
{
  public class SDQLErrorException : Exception
  {
    public SDQLError Error { get; }

    public SDQLErrorException(SDQLError error)
      : this(string.Format("{0}[code={1}]", (object) error.Message, (object) error.Code))
    {
      this.Error = error;
    }

    public SDQLErrorException(string message)
      : base(message)
    {
    }
  }
}
