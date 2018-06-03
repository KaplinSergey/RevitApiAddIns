using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Architectural.Entities;
using Tools.Architectural.Helpers;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Tools.Architectural.Settings;
using Tools.Common.Logger;

namespace Tools.Architectural.Services
{
  public class RoomsService
  {
    private readonly Document _currentDocument;
    private readonly IRoomSettingsProvider _roomSettingsProvider;
    private readonly ILogger _logger;

    public RoomsService(Document currentDocument, IRoomSettingsProvider roomSettingsProvider, ILogger logger)
    {
      _currentDocument = currentDocument;
      _roomSettingsProvider = roomSettingsProvider;
      _logger = logger;
    }

    public IEnumerable<Apartament> GetApartments(IEnumerable<RoomElement> rooms)
    {
      return rooms.GroupBy(r => new { r.ApartmentOwn, r.Purpose }).Select(r => new Apartament(r.Key.Purpose, r.Key.ApartmentOwn, r as IEnumerable<RoomElement>, _roomSettingsProvider));
    }

    public void UpdateApartments(IEnumerable<Apartament> apartaments)
    {
      foreach (Apartament apartment in apartaments)
      {
        double area = apartment.GetArea();
        double residentialArea = apartment.GetResidentialArea();
        double totalArea = apartment.GetTotalArea();
        int roomsCount = apartment.GetRoomsCount();

        this.UpdateRooms(apartment.Rooms, area, residentialArea, totalArea, roomsCount);
      }
    }

    public void UpdateRooms(IEnumerable<RoomElement> rooms, double area, double residentialArea, double totalArea, int roomsCount)
    {
      foreach (RoomElement room in rooms)
      {
        room.ApartmentArea = Math.Round(UnitConverter.ConvertAreaFromMetricToFeet(area), 2);
        room.TotalApartmentArea = Math.Round(UnitConverter.ConvertAreaFromMetricToFeet(totalArea), 2);
        room.ResidentialApartmentArea = Math.Round(UnitConverter.ConvertAreaFromMetricToFeet(residentialArea), 2);
        room.RoomsCount = roomsCount;
        room.AreaCoefficient = room.AreaCoefficient;
        room.DecorationThickness = room.DecorationThickness;
      }
    }

    public void CalculateRoomArea()
    {
      IEnumerable<Apartament> apartments = null;

      try
      {
        IEnumerable<Element> allRoomElements = new FilteredElementCollector(_currentDocument).OfCategory(BuiltInCategory.OST_Rooms).ToElements();
        IEnumerable<RoomElement> rooms = allRoomElements.Select(e => e as Room).Select(r => new RoomElement(r, _roomSettingsProvider)).Where(room => room.HasRequiredProperties() == true);

        apartments = this.GetApartments(rooms);
      }
      catch (Exception e)
      {
        _logger.Log(e.Message);
      }

      try
      {
        using (Transaction currentTransaction = new Transaction(_currentDocument))
        {
          currentTransaction.Start("Change apartments");

          this.UpdateApartments(apartments);

          _currentDocument.Regenerate();
          currentTransaction.Commit();
        }
      }
      catch (Exception e)
      {
        _logger.Log(e.Message);
      }
    }

    public int RevitRoomsCount
    {
      get
      {
        return new FilteredElementCollector(_currentDocument).OfCategory(BuiltInCategory.OST_Rooms).ToElements().Count;
      }
    }

    public int ArchitecturalRoomsCount
    {
      get
      {
        IEnumerable<Element> allRoomElements = new FilteredElementCollector(_currentDocument).OfCategory(BuiltInCategory.OST_Rooms).ToElements();
        return allRoomElements.Select(e => e as Room).Select(r => new RoomElement(r, _roomSettingsProvider)).Where(room => room.HasRequiredProperties() == true).Count();
      }
    }
  }
}
