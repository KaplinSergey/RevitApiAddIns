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

    public void Add(RoomTypeElement room)
    {
      LockItem = false;
      BaseAdd(room);
    }

    public void Remove(RoomTypeElement room)
    {
      LockItem = false;
      BaseRemove(room.RoomTypeName);
    }
  }
}
