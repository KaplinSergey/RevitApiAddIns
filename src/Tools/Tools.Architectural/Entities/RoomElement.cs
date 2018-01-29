using System;
using System.Linq;
using Autodesk.Revit.DB.Architecture;
using Tools.Architectural.Helpers;

namespace Tools.Architectural.Entities
{
  public class RoomElement
  {
    private Room _room;

    public RoomElement(Room room)
    {
      _room = room;
    }

    public double RoomArea
    {
      get
      {
        return Math.Round((UnitConverter.ConvertAreaFromFeetToMetric(_room.Area) - ((_room.Perimeter / 0.0032808398950131) * this.DecorationThickness) / 1000000), 2);
      }
    }

    public string RoomName
    {
      get
      {
        return _room.GetParameters("Имя").FirstOrDefault().AsString();
      }
    }

    public string ApartmentOwn
    {
      get
      {
        return _room.GetParameters("Принадлежность").FirstOrDefault().AsString();
      }
    }

    public int RoomsCount
    {
      set
      {
        _room.GetParameters("Число комнат").FirstOrDefault().Set(value);
      }
    }

    public double TotalApartmentArea
    {
      set
      {
        _room.GetParameters("Площадь квартиры Общая").FirstOrDefault().Set(value);
      }
    }

    public double ApartmentArea
    {
      set
      {
        _room.GetParameters("Площадь квартиры").FirstOrDefault().Set(value);
      }
    }

    public double ResidentialApartmentArea
    {
      set
      {
        _room.GetParameters("Площадь квартиры Жилая").FirstOrDefault().Set(value);
      }
    }

    public int DecorationThickness
    {
      get
      {
        return (int)EnumService.GetDecorationThickness(this.RoomName);
      }
      set
      {
        _room.GetParameters("Толщина внутренней отделки").FirstOrDefault().Set(value * 0.0032808398950131);
      }
    }

    public string Purpose
    {
      get
      {
        return _room.GetParameters("Назначение").FirstOrDefault().AsString();
      }
      set
      {
        _room.GetParameters("Назначение").FirstOrDefault().Set(value);
      }
    }

    public double AreaCoefficient

    {
      get
      {
        return EnumService.GetAreaCoefficient(this.RoomName);
      }
      set
      {
        _room.GetParameters("Коэффициент площади").FirstOrDefault().Set(value);
      }
    }

    public double RoomAreaWithCoefficient
    {
      get
      {
        return Math.Round(this.RoomArea * this.AreaCoefficient, 2);
      }
    }
  }
}
