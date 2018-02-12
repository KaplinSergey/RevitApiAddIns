using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tools.AreaCalculator.Commands
{
  public class DelegateCommand : ICommand
  {
    Func<object, bool> _canExecute;
    Action<object> _executeAction;
    bool _canExecuteCache;

    public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
    {
      _canExecute = canExecute;
      _executeAction = executeAction;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      bool tempCanExecute = _canExecute(parameter);

      if (_canExecuteCache != tempCanExecute)
      {
        _canExecuteCache = tempCanExecute;
        CanExecuteChanged?.Invoke(this, new EventArgs());
      }
      return _canExecuteCache;
    }

    public void Execute(object parameter)
    {
      _executeAction(parameter);
    }
  }
}
