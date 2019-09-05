using System;
using System.Linq;
using Autodesk.Revit.DB.Architecture;
using Tools.Architectural.Helpers;
using Tools.Architectural.Settings;
using Tools.Common.Exceptions.ParameterExceptions;

namespace Tools.Architectural.Entities
{
  public class RoomElement : IRoomElement
  {
    private Room _room;
    private readonly IRoomSettingsProvider _roomSettingsProvider;

    public RoomElement(Room room, IRoomSettingsProvider roomSettingsProvider)
    {
      _room = room;
      _roomSettingsProvider = roomSettingsProvider;
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
        string roomName;
        try
        {
          roomName = _room.GetParameters(_roomSettingsProvider.RoomParameterName).FirstOrDefault().AsString();
        }
        catch (Exception e)
        {
          throw new GetParameterException($"The error has occurred when we tried get room name parameter value. Error message: {e.Message}", e.InnerException);
        }

        return roomName;
      }
    }

    public string ApartmentOwn
    {
      get
      {
        return _room.GetParameters(_roomSettingsProvider.ApartmentOwnParameterName).FirstOrDefault().AsString();
      }
    }

    public int RoomsCount
    {
      set
      {
        _room.GetParameters(_roomSettingsProvider.RoomsCountParameterName).FirstOrDefault().Set(value);
      }
    }

    public double TotalApartmentArea
    {
      set
      {
        _room.GetParameters(_roomSettingsProvider.TotalApartmentAreaParameterName).FirstOrDefault().Set(value);
      }
    }

    public double ApartmentArea
    {
      set
      {
        _room.GetParameters(_roomSettingsProvider.ApartmentAreaParameterName).FirstOrDefault().Set(value);
      }
    }

    public double ResidentialApartmentArea
    {
      set
      {
        _room.GetParameters(_roomSettingsProvider.ResidentialApartmentAreaParameterName).FirstOrDefault().Set(value);
      }
    }

    public int DecorationThickness
    {
      get
      {
        return _roomSettingsProvider.GetDecorationThickness(this.RoomName);
      }
      set
      {
        _room.GetParameters(_roomSettingsProvider.DecorationThicknessParameterName).FirstOrDefault().Set(value * 0.0032808398950131);
      }
    }

    public string Purpose
    {
      get
      {
        return _room.GetParameters(_roomSettingsProvider.PurposeParameterName).FirstOrDefault().AsString();
      }
      set
      {
        _room.GetParameters(_roomSettingsProvider.PurposeParameterName).FirstOrDefault().Set(value);
      }
    }

    public double AreaCoefficient

    {
      get
      {
        return _roomSettingsProvider.GetAreaCoefficient(this.RoomName);
      }
      set
      {
        _room.GetParameters(_roomSettingsProvider.AreaCoefficientParameterName).FirstOrDefault().Set(value);
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
