using System.Configuration;

namespace Tools.AreaCalculator.Configuration
{
  public class RoomSettingsSection : ConfigurationSection
  {
    [ConfigurationProperty("common")]
    public CommonRoomSettings CommonRoomSettings
    {
      get { return (CommonRoomSettings)this["common"]; }
    }

    [ConfigurationCollection(typeof(RoomTypeElement),
      AddItemName = "type",
      ClearItemsName = "clear",
      RemoveItemName = "del")]
    [ConfigurationProperty("roomTypes")]
    public RoomTypeElementCollection RoomTypes
    {
      get { return (RoomTypeElementCollection)this["roomTypes"]; }
    }
  }
}
