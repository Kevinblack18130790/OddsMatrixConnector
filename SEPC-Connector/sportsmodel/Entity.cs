// Decompiled with JetBrains decompiler
// Type: com.oddsmatrix.sepc.connector.sportsmodel.Entity
// Assembly: SEPC-Connector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEF01B39-7A35-429B-9D1B-366801570923
// Assembly location: C:\Users\kacosta\Documents\GitHub\MoverV2\MoverDemonOddsMatrix\bin\Debug\SEPC-Connector.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace com.oddsmatrix.sepc.connector.sportsmodel
{
  public abstract class Entity
  {
    public string EntityType { set; get; }
    public void SetPropertyValue(string propertyName, object value)
    {
      Type type = this.GetType();
      PropertyInfo property = type.GetProperty(propertyName);
      if (property == (PropertyInfo) null)
        throw new ArgumentException("Unknown property " + propertyName + " for " + type.Name);
      if (value.GetType().Equals(typeof (string)) && (string) value == "null")
        value = (object) null;
      TypeConverter converter = TypeDescriptor.GetConverter(property.PropertyType);
      CultureInfo culture = (CultureInfo) CultureInfo.CurrentCulture.Clone();
      culture.NumberFormat.NumberDecimalSeparator = ".";
      property.SetValue((object) this, converter.ConvertFrom((ITypeDescriptorContext) null, culture, value));
    }

    public override string ToString()
    {
      Type type = this.GetType();
      PropertyInfo[] properties = type.GetProperties();
      string str1 = type.Name + "(";
      foreach (PropertyInfo propertyInfo in properties)
      {
        string str2 = str1 + propertyInfo.Name + "=";
        str1 = (propertyInfo.GetValue((object) this) != null ? (!propertyInfo.GetValue((object) this).GetType().Equals(typeof (string)) ? str2 + propertyInfo.GetValue((object) this)?.ToString() : str2 + "\"" + propertyInfo.GetValue((object) this)?.ToString() + "\"") : str2 + "null") + ",";
      }
      return str1.Remove(str1.Length - 1) + ")";
    }
  }
}
