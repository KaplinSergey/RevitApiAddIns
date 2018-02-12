using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Architectural.Entities;
using Tools.Architectural.Helpers;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Tools.Architectural.Settings;

namespace Tools.Architectural.Services
{
  public class RoomsService
  {
    private readonly Document _currentDocument;
    private readonly IRoomSettingsProvider _roomSettingsProvider;

    public RoomsService(Document currentDocument, IRoomSettingsProvider roomSettingsProvider)
    {
      _currentDocument = currentDocument;
      _roomSettingsProvider = roomSettingsProvider;
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
      IEnumerable<Element> allRoomElements = new FilteredElementCollector(_currentDocument).OfCategory(BuiltInCategory.OST_Rooms).ToElements();

      IEnumerable<RoomElement> rooms = allRoomElements.Select(e => e as Room).Select(r => new RoomElement(r, _roomSettingsProvider));

      IEnumerable<Apartament> apartments = null;

      try
      {
        apartments = this.GetApartments(rooms);
      }
      catch (Exception ex)
      {
        TaskDialog.Show("Error", ex.Message);
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
      catch (Exception ex)
      {
        TaskDialog.Show("Error", ex.Message);
      }
    }
  }
}
