// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.util.GZipUtil
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System.IO;
using System.IO.Compression;
using System.Text;

namespace com.oddsmatrix.sepc.connector.util
{
  public static class GZipUtil
  {
    public static byte[] Zip(string inputStr)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(inputStr);
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Compress))
          gzipStream.Write(bytes, 0, bytes.Length);
        return memoryStream.ToArray();
      }
    }

    public static string Unzip(byte[] inputBytes)
    {
      using (MemoryStream memoryStream = new MemoryStream(inputBytes))
      {
        using (GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Decompress))
        {
          using (StreamReader streamReader = new StreamReader((Stream) gzipStream))
            return streamReader.ReadToEnd();
        }
      }
    }
  }
}
