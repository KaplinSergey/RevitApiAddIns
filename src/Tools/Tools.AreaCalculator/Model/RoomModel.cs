namespace Tools.AreaCalculator.Model
{
  public class RoomModel
  {
    public string RoomTypeName { get; set; }
    public int DecorationThicknessValue { get; set; }
    public double AreaCoefficientValue { get; set; }
    public bool IsForAreaCalculation { get; set; }
    public bool IsForResidentialAreaCalculation { get; set; }
    public bool IsForCountCalculation { get; set; }
  }
}
