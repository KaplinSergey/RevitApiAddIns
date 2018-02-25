using Tools.AreaCalculator.ViewModel;

namespace Tools.AreaCalculator
{
  public class Plugin
  {
    private readonly MainWindow _view;

    public Plugin(CalculatorViewModel viewModel)
    {
      _view = new MainWindow(viewModel);
    }

    public void Start()
    {
      _view.ShowDialog();
    }

    public void Stop()
    {
      _view.Close();
    }
  }
}
