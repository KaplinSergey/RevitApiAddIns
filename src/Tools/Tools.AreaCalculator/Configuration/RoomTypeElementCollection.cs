using System.Configuration;

namespace Tools.AreaCalculator.Configuration
{
  public class RoomTypeElementCollection : ConfigurationElementCollection
  {
    protected override ConfigurationElement CreateNewElement()
    {
      return new RoomTypeElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((RoomTypeElement) element).RoomTypeName;
    }
  }
}
