using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Tools.Architectural.Services;
using Tools.AreaCalculator.Commands;
using Tools.AreaCalculator.Model;
using Tools.AreaCalculator.Resources;

namespace Tools.AreaCalculator.ViewModel
{
  public class CalculatorViewModel : INotifyPropertyChanged
  {
    private CalculatorModel _calculatorModel;
    private readonly RoomsService _roomsService;
    private readonly CalculatorRepository _calculatorRepository;
    private readonly Strings _strings;

    private bool flag = true;

    public ICommand SaveCommand { get; set; }
    public ICommand CalculateCommand { get; set; }
    public ICommand Change { get; set; }

    public CalculatorViewModel() : this(new CalculatorRepository(), null)
    {
    }

    public CalculatorViewModel(CalculatorRepository calculatorRepository, RoomsService roomsService)
    {
      _strings = new Strings();
      _roomsService = roomsService;
      _calculatorRepository = calculatorRepository;
      _calculatorModel = calculatorRepository.GetModelFromXml();
      SaveCommand = new DelegateCommand(executeAction => this.Save(), canExecute => true);
      CalculateCommand = new DelegateCommand(executeAction => this.Calculate(), canExecute => true);
      Change = new DelegateCommand(executeAction => this.ChangeLanguage(), canExecute => true);
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

    public Strings Strings
    {
      get { return _strings; }
    }

    public IList<RoomModel> RoomTypes
    {
      get { return _calculatorModel.RoomTypes; }
    }

    public void Save()
    {
      _calculatorRepository.SaveModelToXml(_calculatorModel);
    }

    public void Calculate()
    {     
      _roomsService.CalculateRoomArea();
    }

    public bool IsRuLanguage
    {
      get { return !_calculatorModel.IsRuLanguage; }
      set { _calculatorModel.IsRuLanguage = value; }
    }

    public bool IsEngLanguage
    {
      get { return !_calculatorModel.IsEngLanguage; }
      set { _calculatorModel.IsEngLanguage = value; }
    }

    public void ChangeLanguage()
    {
      IsRuLanguage = IsRuLanguage;
      IsEngLanguage = IsEngLanguage;

      OnPropertyChanged("IsRuLanguage");
      OnPropertyChanged("IsEngLanguage");

      string culture = !IsEngLanguage ? string.Empty : "ru-Ru";

      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

      OnPropertyChanged("Strings");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
