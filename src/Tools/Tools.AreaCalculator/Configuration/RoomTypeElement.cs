using System.Configuration;

namespace Tools.AreaCalculator.Configuration
{
  public class RoomTypeElement : ConfigurationElement
  {
    [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
    public string RoomTypeName
    {
      get { return (string)this["name"]; }
      set { this["name"] = value; }
    }

    [ConfigurationProperty("decorationThicknessValue")]
    public string DecorationThicknessValue
    {
      get { return (string) this["decorationThicknessValue"]; }
      set { this["decorationThicknessValue"] = value; }
    }

    [ConfigurationProperty("areaCoefficientValue")]
    public string AreaCoefficientValue
    {
      get { return (string)this["areaCoefficientValue"]; }
      set { this["areaCoefficientValue"] = value; }
    }
  }
}
