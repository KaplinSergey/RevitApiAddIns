using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Architectural.Entities;
using Tools.Architectural.Helpers;

namespace Tools.Architectural.Services
{
  public class RoomsService
  {
    public IEnumerable<Apartament> GetApartments(IEnumerable<RoomElement> rooms)
    {
      return rooms.GroupBy(r => new { r.ApartmentOwn, r.Purpose }).Select(r => new Apartament(r.Key.Purpose, r.Key.ApartmentOwn, r as IEnumerable<RoomElement>));
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
  }
}
