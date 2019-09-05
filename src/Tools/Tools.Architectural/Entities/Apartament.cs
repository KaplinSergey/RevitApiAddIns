using System.Collections.Generic;
using System.Linq;
using Tools.Architectural.Settings;

namespace Tools.Architectural.Entities
{
  public class Apartament
  {
    private readonly string _apartmentPurpose;
    private readonly string _apartmentOwn;
    private readonly IEnumerable<IRoomElement> _rooms;
    private readonly IRoomSettingsProvider _roomSettingsProvider;

    public Apartament(string apartmentPurpose, string apartmentOwn, IEnumerable<IRoomElement> rooms, IRoomSettingsProvider roomSettingsProvider)
    {
      _rooms = rooms;
      _apartmentPurpose = apartmentPurpose;
      _apartmentOwn = apartmentOwn;
      _roomSettingsProvider = roomSettingsProvider;
    }

    public IEnumerable<IRoomElement> Rooms
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
      return _rooms.Where(r => _roomSettingsProvider.RoomsForAreaCalculation().Contains(r.RoomName)).Aggregate(0.0, (s, i) => s + i.RoomAreaWithCoefficient);
    }

    public double GetResidentialArea()
    {
      return _rooms.Where(r => _roomSettingsProvider.RoomsForResidentialAreaCalculation().Contains(r.RoomName)).Aggregate(0.0, (s, i) => s + i.RoomAreaWithCoefficient);
    }

    public int GetRoomsCount()
    {
      return _rooms.Count(r => _roomSettingsProvider.RoomsForCountCalculation().Contains(r.RoomName));
    }
  }
}
