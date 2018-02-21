using System.Collections.Generic;

namespace Tools.AreaCalculator.Model
{
  public class CalculatorModel
  {
    public string Purpose { get; set; }
    public string ApartmentOwn { get; set; }
    public string RoomName { get; set; }
    public string RoomsCount { get; set; }
    public string TotalApartmentArea { get; set; }
    public string ApartmentArea { get; set; }
    public string ResidentialApartmentArea { get; set; }
    public string DecorationThickness { get; set; }
    public string AreaCoefficient { get; set; }
    public IList<RoomModel> RoomTypes { get; set; }   
  }
}
