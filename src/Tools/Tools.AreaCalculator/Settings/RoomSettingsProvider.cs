using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Tools.Architectural.Settings;
using Tools.AreaCalculator.Configuration;

namespace Tools.AreaCalculator.Settings
{
  public class RoomSettingsProvider : IRoomSettingsProvider
  {
    private readonly RoomSettingsSection _roomSettingsSection;

    public RoomSettingsProvider()
    {
      _roomSettingsSection = (RoomSettingsSection)ConfigurationManager.GetSection("roomSettings");
    }

    public int GetDecorationThickness(string roomName)
    {
      return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().First(r => r.RoomTypeName == roomName)
        .DecorationThicknessValue;
    }

    public double GetAreaCoefficient(string roomName)
    {
      return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().First(r => r.RoomTypeName == roomName)
        .AreaCoefficientValue;
    }

    public string RoomParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.RoomName; }
    }

    public string ApartmentOwnParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.ApartmentOwn; }
    }

    public string RoomsCountParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.RoomsCount; }
    }
    public string TotalApartmentAreaParameterName { get; }
    public string ApartmentAreaParameterName { get; }
    public string ResidentialApartmentAreaParameterName { get; }
    public string DecorationThicknessParameterName { get; }
    public string PurposeParameterName { get; }
    public string AreaCoefficientParameterName { get; }
    public IEnumerable<string> RoomsForAreaCalculation()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> RoomsForResidentialCalculation()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> RoomsForCountCalculation()
    {
      throw new NotImplementedException();
    }
  }
}
