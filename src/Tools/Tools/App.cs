using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Tools
{
  class App : IExternalApplication
  {
    public Result OnStartup(UIControlledApplication a)
    {
      RibbonPanel ribbonPanel = this.GetRibbonPanel(a);

      string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

      PushButton button = ribbonPanel.AddItem(new PushButtonData("RoomsArea", "Rooms Area", thisAssemblyPath, "Tools.AreaCalculator")) as PushButton;
      button.ToolTip = "Calculate rooms area";
      //button.LargeImage = ImageConverter.BitmapToImageSource(Images.RoomArea);

      return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication a)
    {
      return Result.Succeeded;
    }

    private RibbonPanel GetRibbonPanel(UIControlledApplication a)
    {
      string tabName = "Architectural Tools";
      string panelName = "Architectural";

      try
      {
        a.CreateRibbonTab(tabName);
      }
      catch (Exception)
      { }

      try
      {
        a.CreateRibbonPanel(tabName, panelName);
      }
      catch (Exception)
      { }

      IEnumerable<RibbonPanel> ribbonPanels = a.GetRibbonPanels(tabName);
      return ribbonPanels.FirstOrDefault(p => p.Name == panelName);
    }
  }
}
