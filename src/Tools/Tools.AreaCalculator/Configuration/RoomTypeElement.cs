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
    public int DecorationThicknessValue
    {
      get { return (int)this["decorationThicknessValue"]; }
      set { this["decorationThicknessValue"] = value; }
    }

    [ConfigurationProperty("areaCoefficientValue")]
    public double AreaCoefficientValue
    {
      get { return (double)this["areaCoefficientValue"]; }
      set { this["areaCoefficientValue"] = value; }
    }

    [ConfigurationProperty("isForAreaCalculation")]
    public bool IsForAreaCalculation
    {
      get { return (bool)this["isForAreaCalculation"]; }
      set { this["isForAreaCalculation"] = value; }
    }

    [ConfigurationProperty("isForResidentialAreaCalculation")]
    public bool IsForResidentialAreaCalculation
    {
      get { return (bool)this["isForResidentialAreaCalculation"]; }
      set { this["isForResidentialAreaCalculation"] = value; }
    }

    [ConfigurationProperty("isForCountCalculation")]
    public bool IsForCountCalculation
    {
      get { return (bool)this["isForCountCalculation"]; }
      set { this["isForCountCalculation"] = value; }
    }

    protected override bool IsModified()
    {
      return true;
    }
  }
}
