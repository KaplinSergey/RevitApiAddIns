using System.Collections.Generic;
using System.Windows.Input;
using Tools.Architectural.Services;
using Tools.AreaCalculator.Commands;
using Tools.AreaCalculator.Model;

namespace Tools.AreaCalculator.ViewModel
{
  public class CalculatorViewModel
  {
    private CalculatorModel _calculatorModel;
    private readonly RoomsService _roomsService;
    private readonly CalculatorRepository _calculatorRepository;

    public ICommand SaveCommand { get; set; }
    public ICommand CalculateCommand { get; set; }

    public CalculatorViewModel() : this(new CalculatorRepository(), null)
    {
    }

    public CalculatorViewModel(CalculatorRepository calculatorRepository, RoomsService roomsService)
    {
      _roomsService = roomsService;
      _calculatorRepository = calculatorRepository;
      _calculatorModel = calculatorRepository.GetModel();
      SaveCommand = new DelegateCommand(executeAction => this.Save(), canExecute => true);
      CalculateCommand = new DelegateCommand(executeAction => this.Calculate(), canExecute => true);
    }

    public string Purpose
    {
      get { return _calculatorModel.Purpose; }
      set { _calculatorModel.Purpose = value; }
    }

    public string ApartmentOwn
    {
      get { return _calculatorModel.ApartmentOwn; }
      set { _calculatorModel.ApartmentOwn = value; }
    }
    public string RoomName
    {
      get { return _calculatorModel.RoomName; }
      set { _calculatorModel.RoomName = value; }
    }
    public string RoomsCount
    {
      get { return _calculatorModel.RoomsCount; }
      set { _calculatorModel.RoomsCount = value; }
    }
    public string TotalApartmentArea
    {
      get { return _calculatorModel.TotalApartmentArea; }
      set { _calculatorModel.TotalApartmentArea = value; }
    }
    public string ApartmentArea
    {
      get { return _calculatorModel.ApartmentArea; }
      set { _calculatorModel.ApartmentArea = value; }
    }
    public string ResidentialApartmentArea
    {
      get { return _calculatorModel.ResidentialApartmentArea; }
      set { _calculatorModel.ResidentialApartmentArea = value; }
    }
    public string DecorationThickness
    {
      get { return _calculatorModel.DecorationThickness; }
      set { _calculatorModel.DecorationThickness = value; }
    }
    public string AreaCoefficient
    {
      get { return _calculatorModel.AreaCoefficient; }
      set { _calculatorModel.AreaCoefficient = value; }
    }

    public IList<RoomModel> RoomTypes
    {
      get { return _calculatorModel.RoomTypes; }
    }

    public void Save()
    {
      _calculatorRepository.SaveModel(_calculatorModel);
    }

    public void Calculate()
    {     
      _roomsService.CalculateRoomArea();
    }   
  }
}
