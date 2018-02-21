using Autodesk.Revit.UI;
using Tools.Common.Logger;

namespace Tools.Loggers
{
  public class DefaultLogger : ILogger
  {
    public void Log(string message)
    {
      TaskDialog.Show("Error", message);
    }
  }
}
