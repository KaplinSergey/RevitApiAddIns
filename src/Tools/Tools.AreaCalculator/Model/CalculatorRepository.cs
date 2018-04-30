using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tools.AreaCalculator.Model
{
  public class CalculatorRepository
  {
    public event EventHandler ModelChanged;

    public CalculatorModel GetModelFromXml()
    {
      CalculatorModel model;

      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Autodesk\Revit\Addins\2017\AreaCalculatorSettings.xml");

      if (!File.Exists(path))
      {
        return this.GetDefaultModel();
      }

      var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
      var serializer = new XmlSerializer(typeof(CalculatorModel));
      model = serializer.Deserialize(stream) as CalculatorModel;
      stream.Close();

      return model;
    }

    public void SaveModelToXml(CalculatorModel model)
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Autodesk\Revit\Addins\2017\AreaCalculatorSettings.xml");

      var stream = new FileStream(path, FileMode.Create);
      var serializer = new XmlSerializer(typeof(CalculatorModel));
      serializer.Serialize(stream, model);
      stream.Close();

      this.OnModelChanged(this, EventArgs.Empty);
    }

    protected void OnModelChanged(object sender, EventArgs e)
    {
      ModelChanged?.Invoke(sender, e);
    }

    private CalculatorModel GetDefaultModel()
    {
      return new CalculatorModel
      {
        Purpose = "Назначение",
        ApartmentOwn = "Принадлежность",
        RoomName = "Имя",
        RoomsCount = "Число комнат",
        TotalApartmentArea = "Площадь квартиры Общая",
        ApartmentArea = "Площадь квартиры",
        ResidentialApartmentArea = "Площадь квартиры Жилая",
        DecorationThickness = "Толщина внутренней отделки",
        AreaCoefficient = "Коэффициент площади",
        RoomTypes = new List<RoomModel>
        {
          new RoomModel
          {
            RoomTypeName = "Остальные",
            AreaCoefficientValue = 1,
            DecorationThicknessValue = 20,
            IsForAreaCalculation = true,
            IsForCountCalculation = true,
            IsForResidentialAreaCalculation = true
          },
          new RoomModel
          {
            RoomTypeName = "Лоджия",
            AreaCoefficientValue = 0.7,
            DecorationThicknessValue = 0,
            IsForAreaCalculation = true,
            IsForCountCalculation = false,
            IsForResidentialAreaCalculation = false
          },
          new RoomModel
          {
            RoomTypeName = "Балкон",
            AreaCoefficientValue = 0.5,
            DecorationThicknessValue = 0,
            IsForAreaCalculation = true,
            IsForCountCalculation = false,
            IsForResidentialAreaCalculation = false
          },
          new RoomModel
          {
            RoomTypeName = "Терраса",
            AreaCoefficientValue = 0.3,
            DecorationThicknessValue = 20,
            IsForAreaCalculation = true,
            IsForCountCalculation = false,
            IsForResidentialAreaCalculation = false
          }
        },
        IsRuLanguage = true,
        IsEngLanguage = false
      };
    }
  }
}
