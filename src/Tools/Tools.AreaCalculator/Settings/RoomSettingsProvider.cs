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

    public string TotalApartmentAreaParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.TotalApartmentArea; }
    }

    public string ApartmentAreaParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.ApartmentArea; }
    }

    public string ResidentialApartmentAreaParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.ResidentialApartmentArea; }
    }

    public string DecorationThicknessParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.DecorationThickness; }
    }

    public string PurposeParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.Purpose; }
    }

    public string AreaCoefficientParameterName
    {
      get { return _roomSettingsSection.CommonRoomSettings.AreaCoefficient; }
    }

    public IEnumerable<string> RoomsForAreaCalculation()
    {
      return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().Where(r => r.IsForAreaCalculation).Select(r => r.RoomTypeName);
    }

    public IEnumerable<string> RoomsForResidentialAreaCalculation()
    {
      return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().Where(r => r.IsForResidentialAreaCalculation).Select(r => r.RoomTypeName);
    }

    public IEnumerable<string> RoomsForCountCalculation()
    {
      return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().Where(r => r.IsForCountCalculation).Select(r => r.RoomTypeName);
    }
  }
}
