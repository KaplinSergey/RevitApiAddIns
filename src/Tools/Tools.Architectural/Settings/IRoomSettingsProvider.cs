using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Architectural.Settings
{
  public interface IRoomSettingsProvider
  {
    int GetDecorationThickness(string roomName);
    double GetAreaCoefficient(string roomName);
    string RoomParameterName { get; }
    string ApartmentOwnParameterName { get; }
    string RoomsCountParameterName { get; }
    string TotalApartmentAreaParameterName { get; }
    string ApartmentAreaParameterName { get; }
    string ResidentialApartmentAreaParameterName { get; }
    string DecorationThicknessParameterName { get; }
    string PurposeParameterName { get; }
    string AreaCoefficientParameterName { get; }
    IEnumerable<string> RoomsForAreaCalculation();
    IEnumerable<string> RoomsForResidentialCalculation();
    IEnumerable<string> RoomsForCountCalculation();
  }
}
