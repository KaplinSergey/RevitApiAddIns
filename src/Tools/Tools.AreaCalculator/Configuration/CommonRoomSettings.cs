using System.Configuration;

namespace Tools.AreaCalculator.Configuration
{
  public class CommonRoomSettings : ConfigurationElement
  {
    [ConfigurationProperty("purpose")]
    public string Purpose
    {
      get { return (string)this["purpose"]; }
      set { this["purpose"] = value; }
    }

    [ConfigurationProperty("apartmentOwn")]
    public string ApartmentOwn
    {
      get { return (string)this["apartmentOwn"]; }
      set { this["apartmentOwn"] = value; }
    }

    [ConfigurationProperty("roomName")]
    public string RoomName
    {
      get { return (string)this["roomName"]; }
      set { this["roomName"] = value; }
    }

    [ConfigurationProperty("roomsCount")]
    public string RoomsCount
    {
      get { return (string)this["roomsCount"]; }
      set { this["roomsCount"] = value; }
    }

    [ConfigurationProperty("totalApartmentArea")]
    public string TotalApartmentArea
    {
      get { return (string)this["totalApartmentArea"]; }
      set { this["totalApartmentArea"] = value; }
    }

    [ConfigurationProperty("apartmentArea")]
    public string ApartmentArea
    {
      get { return (string)this["apartmentArea"]; }
      set { this["apartmentArea"] = value; }
    }

    [ConfigurationProperty("residentialApartmentArea")]
    public string ResidentialApartmentArea
    {
      get { return (string)this["residentialApartmentArea"]; }
      set { this["residentialApartmentArea"] = value; }
    }

    [ConfigurationProperty("decorationThickness")]
    public string DecorationThickness
    {
      get { return (string)this["decorationThickness"]; }
      set { this["decorationThickness"] = value; }
    }

    [ConfigurationProperty("areaCoefficient")]
    public string AreaCoefficient
    {
      get { return (string)this["areaCoefficient"]; }
      set { this["areaCoefficient"] = value; }
    }

    protected override bool IsModified()
    {
      return true;
    }
  }
}
