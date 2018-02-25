using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Tools.Architectural.Services;
using Tools.AreaCalculator.Model;
using Tools.AreaCalculator;
using Tools.AreaCalculator.Settings;
using Tools.AreaCalculator.ViewModel;
using Tools.Loggers;

namespace Tools
{
  [Transaction(TransactionMode.Manual)]
  public class AreaCalculatorCommand : IExternalCommand
  {
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements)
    {
      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;

      DefaultLogger logger = new DefaultLogger();
      Plugin app = null;

      try
      {
        CalculatorRepository repository = new CalculatorRepository();
        CalculatorViewModel viewModel = new CalculatorViewModel(repository, new RoomsService(uidoc.Document, new RoomSettingsProvider(repository), logger));
        app = new Plugin(viewModel);
        app.Start();
      }
      catch (Exception)
      {
        logger.Log("An error has occurred ");
        app?.Stop();
      }
      
      return Result.Succeeded;
    }   
  }
}
