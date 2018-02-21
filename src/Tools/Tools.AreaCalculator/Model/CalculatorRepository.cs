using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.AreaCalculator.Configuration;

namespace Tools.AreaCalculator.Model
{
  public class CalculatorRepository
  {
    public CalculatorModel GetModel()
    {
      var roomSettingsSection = (RoomSettingsSection)ConfigurationManager.GetSection("roomSettings");
      return new CalculatorModel
      {
        Purpose = roomSettingsSection.CommonRoomSettings.Purpose,
        ApartmentOwn = roomSettingsSection.CommonRoomSettings.ApartmentOwn,
        RoomName = roomSettingsSection.CommonRoomSettings.RoomName,
        RoomsCount = roomSettingsSection.CommonRoomSettings.RoomsCount,
        TotalApartmentArea = roomSettingsSection.CommonRoomSettings.TotalApartmentArea,
        ApartmentArea = roomSettingsSection.CommonRoomSettings.ApartmentArea,
        ResidentialApartmentArea = roomSettingsSection.CommonRoomSettings.ResidentialApartmentArea,
        DecorationThickness = roomSettingsSection.CommonRoomSettings.DecorationThickness,
        AreaCoefficient = roomSettingsSection.CommonRoomSettings.AreaCoefficient,
        RoomTypes = roomSettingsSection.RoomTypes.OfType<RoomTypeElement>()
          .Select(r => new RoomModel
          {
            RoomTypeName = r.RoomTypeName,
            AreaCoefficientValue = r.AreaCoefficientValue,
            DecorationThicknessValue = r.DecorationThicknessValue,
            IsForAreaCalculation = r.IsForAreaCalculation,
            IsForCountCalculation = r.IsForCountCalculation,
            IsForResidentialAreaCalculation = r.IsForResidentialAreaCalculation
          }).ToList()
      };
    }

    public void SaveModel(CalculatorModel model)
    {
      System.Configuration.Configuration exeConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      RoomSettingsSection roomSettingsSection = (RoomSettingsSection)exeConfiguration.GetSection("roomSettings");

      roomSettingsSection.CommonRoomSettings.Purpose = model.Purpose;
      roomSettingsSection.CommonRoomSettings.ApartmentOwn = model.ApartmentOwn;
      roomSettingsSection.CommonRoomSettings.RoomName = model.RoomName;
      roomSettingsSection.CommonRoomSettings.RoomsCount = model.RoomsCount;
      roomSettingsSection.CommonRoomSettings.TotalApartmentArea = model.TotalApartmentArea;
      roomSettingsSection.CommonRoomSettings.ApartmentArea = model.ApartmentArea;
      roomSettingsSection.CommonRoomSettings.ResidentialApartmentArea = model.ResidentialApartmentArea;
      roomSettingsSection.CommonRoomSettings.DecorationThickness = model.DecorationThickness;
      roomSettingsSection.CommonRoomSettings.AreaCoefficient = model.AreaCoefficient;

      roomSettingsSection.RoomTypes.Clear();

      foreach (var roomType in model.RoomTypes)
      {
        roomSettingsSection.RoomTypes.Add(new RoomTypeElement
        {
          RoomTypeName = roomType.RoomTypeName,
          AreaCoefficientValue = roomType.AreaCoefficientValue,
          DecorationThicknessValue = roomType.DecorationThicknessValue,
          IsForAreaCalculation = roomType.IsForAreaCalculation,
          IsForCountCalculation = roomType.IsForCountCalculation,
          IsForResidentialAreaCalculation = roomType.IsForResidentialAreaCalculation
        });
      }

      exeConfiguration.Save(ConfigurationSaveMode.Full);
      ConfigurationManager.RefreshSection("roomSettings");
    }
  }
}
