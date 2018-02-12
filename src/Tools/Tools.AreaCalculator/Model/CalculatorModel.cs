using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Architectural.Services;
using Tools.AreaCalculator.Configuration;

namespace Tools.AreaCalculator.Model
{
  public class CalculatorModel
  {
    private readonly RoomSettingsSection _roomSettingsSection;
    private readonly RoomsService _roomsService;

    public CalculatorModel(RoomSettingsSection roomSettingsSection, RoomsService roomsService = null)
    {
      _roomSettingsSection = roomSettingsSection;
      _roomsService = roomsService;
    }

    public string Purpose
    {
      get { return _roomSettingsSection.CommonRoomSettings.Purpose; }
      set { _roomSettingsSection.CommonRoomSettings.Purpose = value; }
    }

    public IList<RoomTypeElement> RoomTypes
    {
      get { return _roomSettingsSection.RoomTypes.OfType<RoomTypeElement>().ToList(); }
    }

    public void Save()
    {
      _roomSettingsSection.CommonRoomSettings.Purpose = "Назначение1";
    }

    public void Calculate()
    {
      _roomsService.CalculateRoomArea();
    }

    //System.Configuration.Configuration exeConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    //RouteTableSection r = (RouteTableSection)exeConfiguration.GetSection("routeTable");
    //Console.WriteLine(r.DefaultRoute.AddDate);
    //  r.DefaultRoute.AddDate = true;
    //  //r.RegisteredRoutes.Add(new RouteElement {AddIndexNumber = true, FileNamePattern = "Test1"});
    //  r.RegisteredRoutes.Remove(new RouteElement { AddIndexNumber = true, FileNamePattern = "Test2" });
    //  exeConfiguration.Save(ConfigurationSaveMode.Full);
    //  ConfigurationManager.RefreshSection("routeTable");
    //  Console.WriteLine(r.DefaultRoute.AddDate);

  }
}
