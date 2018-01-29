namespace Tools.Architectural.Helpers
{
  public class UnitConverter
  {
    public static double ConvertAreaFromFeetToMetric(double areaInFeet)
    {
      return areaInFeet * 0.092903411613;
    }

    public static double ConvertAreaFromMetricToFeet(double areaInMetric)
    {
      return areaInMetric / 0.092903411613;
    }
  }
}
