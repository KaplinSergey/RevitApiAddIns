using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Tools.AreaCalculator.Model;
using Tools.AreaCalculator;

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

      //CalculatorModel calculator = new CalculatorModel(uidoc);
      

      return Result.Succeeded;
    }   
  }
}
