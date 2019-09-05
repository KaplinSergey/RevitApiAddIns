using System;
using Tools.Architectural.Entities;
using Tools.Architectural.Helpers;
using Tools.Architectural.Settings;

namespace Tools.Architectural.Tests.Entities.Mocks
{
  public class RoomElementMock : IRoomElement
  {
    private readonly double _areaInFeet;
    private readonly double _perimeterInFeet;
    private readonly IRoomSettingsProvider _roomSettingsProvider;

    public RoomElementMock(string name, double areaInFeet, double perimeterInFeet,
      IRoomSettingsProvider roomSettingsProvider)
    {
      this.RoomName = name;
      _areaInFeet = areaInFeet;
      _perimeterInFeet = perimeterInFeet;
      _roomSettingsProvider = roomSettingsProvider;
    }

    public string RoomName { get; }

    public double RoomArea =>
      Math.Round(
        UnitConverter.ConvertAreaFromFeetToMetric(_areaInFeet) -
        _perimeterInFeet / 0.0032808398950131 * this.DecorationThickness / 1000000, 2);

    public string ApartmentOwn { get; }
    public int RoomsCount { get; set; }
    public double TotalApartmentArea { get; set; }
    public double ApartmentArea { get; set; }
    public double ResidentialApartmentArea { get; set; }

    public int DecorationThickness
    {
      get => _roomSettingsProvider.GetDecorationThickness(this.RoomName);
      set { }
    }

    public string Purpose { get; set; }

    public double AreaCoefficient
    {
      get => _roomSettingsProvider.GetAreaCoefficient(this.RoomName);
      set { }
    }

    public double RoomAreaWithCoefficient => Math.Round(this.RoomArea * this.AreaCoefficient, 2);
  }
}