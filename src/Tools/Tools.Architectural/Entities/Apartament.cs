using System.Collections.Generic;
using System.Linq;

namespace Tools.Architectural.Entities
{
  public class Apartament
  {
    private readonly string _apartmentPurpose;
    private readonly string _apartmentOwn;
    private readonly IEnumerable<RoomElement> _rooms;

    public Apartament(string apartmentPurpose, string apartmentOwn, IEnumerable<RoomElement> rooms)
    {
      _rooms = rooms;
      _apartmentPurpose = apartmentPurpose;
      _apartmentOwn = apartmentOwn;
    }

    public IEnumerable<RoomElement> Rooms
    {
      get
      {
        return _rooms;
      }
    }

    public string ApartmentPurpose
    {
      get
      {
        return _apartmentPurpose;
      }
    }

    public string ApartmentOwn
    {
      get
      {
        return _apartmentOwn;
      }
    }

    public double GetTotalArea()
    {
      return _rooms.Aggregate(0.0, (s, i) => s + i.RoomAreaWithCoefficient);
    }

    public double GetArea()
    {
      return _rooms.Where(r => r.RoomName != "Лоджия" || r.RoomName != "Терраса" || r.RoomName != "Балкон").Aggregate(0.0, (s, i) => s + i.RoomAreaWithCoefficient);
    }

    public double GetResidentialArea()
    {
      return _rooms.Where(r => r.RoomName == "Жилая комната" || r.RoomName == "Жилая комната с кухонным оборудованием").Aggregate(0.0, (s, i) => s + i.RoomAreaWithCoefficient);
    }

    public int GetRoomsCount()
    {
      return _rooms.Count(r => r.RoomName == "Жилая комната" || r.RoomName == "Жилая комната с кухонным оборудованием");
    }
  }
}
