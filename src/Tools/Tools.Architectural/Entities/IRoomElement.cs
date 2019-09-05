namespace Tools.Architectural.Entities
{
  public interface IRoomElement
  {
    string RoomName { get; }
    double RoomArea { get; }
    string ApartmentOwn { get; }
    int RoomsCount { set; }
    double TotalApartmentArea { set; }
    double ApartmentArea { set; }
    double ResidentialApartmentArea { set; }
    int DecorationThickness { get; set; }
    string Purpose { get; set; }
    double AreaCoefficient { get; set; }
    double RoomAreaWithCoefficient { get; }
  }
}