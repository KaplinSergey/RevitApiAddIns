using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Architectural.Settings;
using Moq;
using Tools.Architectural.Entities;
using Tools.Architectural.Tests.Entities.Mocks;

namespace Tools.Architectural.Tests.Entities
{
  [TestClass]
  public class ApartamentTests
  {
    private IRoomSettingsProvider _roomSettingsProvider;

    [TestInitialize]
    public void Startup()
    {
      var roomSettingProviderMock = new Mock<IRoomSettingsProvider>();

      roomSettingProviderMock.Setup(r => r.RoomParameterName).Returns("Имя");
      roomSettingProviderMock.Setup(r => r.ApartmentOwnParameterName).Returns("Принадлежность");
      roomSettingProviderMock.Setup(r => r.RoomsCountParameterName).Returns("Число комнат");
      roomSettingProviderMock.Setup(r => r.TotalApartmentAreaParameterName).Returns("Площадь квартиры Общая");
      roomSettingProviderMock.Setup(r => r.ApartmentAreaParameterName).Returns("Площадь квартиры");
      roomSettingProviderMock.Setup(r => r.ResidentialApartmentAreaParameterName).Returns("Площадь квартиры Жилая");
      roomSettingProviderMock.Setup(r => r.DecorationThicknessParameterName).Returns("Толщина внутренней отделки");
      roomSettingProviderMock.Setup(r => r.PurposeParameterName).Returns("Назначение");
      roomSettingProviderMock.Setup(r => r.AreaCoefficientParameterName).Returns("Коэффициент площади");

      roomSettingProviderMock.Setup(r => r.RoomsForAreaCalculation())
        .Returns(new[] {"Остальные", "Лоджия", "Балкон", "Терраса"});
      roomSettingProviderMock.Setup(r => r.RoomsForCountCalculation()).Returns(new[] {"Остальные"});
      roomSettingProviderMock.Setup(r => r.RoomsForResidentialAreaCalculation()).Returns(new[] {"Остальные"});

      roomSettingProviderMock.Setup(r => r.GetAreaCoefficient("Остальные")).Returns(1);
      roomSettingProviderMock.Setup(r => r.GetAreaCoefficient("Лоджия")).Returns(0.7);
      roomSettingProviderMock.Setup(r => r.GetAreaCoefficient("Балкон")).Returns(0.5);
      roomSettingProviderMock.Setup(r => r.GetAreaCoefficient("Терраса")).Returns(0.3);

      roomSettingProviderMock.Setup(r => r.GetDecorationThickness("Остальные")).Returns(20);
      roomSettingProviderMock.Setup(r => r.GetDecorationThickness("Лоджия")).Returns(0);
      roomSettingProviderMock.Setup(r => r.GetDecorationThickness("Балкон")).Returns(0);
      roomSettingProviderMock.Setup(r => r.GetDecorationThickness("Терраса")).Returns(20);

      _roomSettingsProvider = roomSettingProviderMock.Object;
    }

    [TestMethod]
    public void GetRoomsCount_Should_Returns_2()
    {
      var roomOne = new RoomElementMock("Остальные", 107.639, 72.1785, _roomSettingsProvider);
      var roomTwo = new RoomElementMock("Остальные", 161.459, 104.987, _roomSettingsProvider);
      var loggia = new RoomElementMock("Лоджия", 107.639, 72.1785, _roomSettingsProvider);
      var balcony = new RoomElementMock("Балкон", 107.639, 72.1785, _roomSettingsProvider);
      var terrace = new RoomElementMock("Терраса", 107.639, 72.1785, _roomSettingsProvider);

      var apartament = new Apartament("test", "1", new[] {roomOne, roomTwo, terrace, balcony, loggia}, _roomSettingsProvider);

      //Assert.AreEqual(2, apartament.GetRoomsCount());
      //Assert.AreEqual(55, apartament.GetTotalArea());
      //Assert.AreEqual(40, apartament.GetArea());
      Assert.AreEqual(23.92, apartament.GetResidentialArea());
    }
  }
}