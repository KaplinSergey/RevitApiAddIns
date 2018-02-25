using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Tools.Architectural.Settings;
using Tools.AreaCalculator.Model;

namespace Tools.AreaCalculator.Settings
{
  public class RoomSettingsProvider : IRoomSettingsProvider
  {
    private readonly CalculatorRepository _calculatorRepository;
    private CalculatorModel _model;

    public RoomSettingsProvider(CalculatorRepository calculatorRepository)
    {
      _calculatorRepository = calculatorRepository;
      _calculatorRepository.ModelChanged += CalculatorRepositoryModelChanged;
      _model = _calculatorRepository.GetModelFromXml();

    }

    private void CalculatorRepositoryModelChanged(object sender, EventArgs e)
    {
      _model = _calculatorRepository.GetModelFromXml();
    }

    public int GetDecorationThickness(string roomName)
    {
      return _model.RoomTypes.First(r => r.RoomTypeName == roomName)
        .DecorationThicknessValue;
    }

    public double GetAreaCoefficient(string roomName)
    {
      return _model.RoomTypes.First(r => r.RoomTypeName == roomName)
        .AreaCoefficientValue;
    }

    public string RoomParameterName
    {
      get { return _model.RoomName; }
    }

    public string ApartmentOwnParameterName
    {
      get { return _model.ApartmentOwn; }
    }

    public string RoomsCountParameterName
    {
      get { return _model.RoomsCount; }
    }

    public string TotalApartmentAreaParameterName
    {
      get { return _model.TotalApartmentArea; }
    }

    public string ApartmentAreaParameterName
    {
      get { return _model.ApartmentArea; }
    }

    public string ResidentialApartmentAreaParameterName
    {
      get { return _model.ResidentialApartmentArea; }
    }

    public string DecorationThicknessParameterName
    {
      get { return _model.DecorationThickness; }
    }

    public string PurposeParameterName
    {
      get { return _model.Purpose; }
    }

    public string AreaCoefficientParameterName
    {
      get { return _model.AreaCoefficient; }
    }

    public IEnumerable<string> RoomsForAreaCalculation()
    {
      return _model.RoomTypes.Where(r => r.IsForAreaCalculation).Select(r => r.RoomTypeName);
    }

    public IEnumerable<string> RoomsForResidentialAreaCalculation()
    {
      return _model.RoomTypes.Where(r => r.IsForResidentialAreaCalculation).Select(r => r.RoomTypeName);
    }

    public IEnumerable<string> RoomsForCountCalculation()
    {
      return _model.RoomTypes.Where(r => r.IsForCountCalculation).Select(r => r.RoomTypeName);
    }
  }
}
