using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools.AreaCalculator.Commands;
using Tools.AreaCalculator.Configuration;
using Tools.AreaCalculator.Model;

namespace Tools.AreaCalculator.ViewModel
{
  public class CalculatorViewModel
  {
    private readonly CalculatorModel _calculatorModel;

    public ICommand SaveCommand { get; set; }
    public ICommand CalculateCommand { get; set; }

    public CalculatorViewModel() : this(new CalculatorModel((RoomSettingsSection)ConfigurationManager.GetSection("roomSettings")))
    {
    }

    public CalculatorViewModel(CalculatorModel calculatorModel)
    {
      _calculatorModel = calculatorModel;
      SaveCommand = new DelegateCommand(executeAction => _calculatorModel.Save(), canExecute => true);
      CalculateCommand = new DelegateCommand(executeAction => _calculatorModel.Save(), canExecute => true);
    }

    public string Purpose
    {
      get { return _calculatorModel.Purpose; }
      set { _calculatorModel.Purpose = value; }
    }

    public IList<RoomTypeElement> RoomTypes
    {
      get { return _calculatorModel.RoomTypes.OfType<RoomTypeElement>().ToList(); }
    }
  }
}
