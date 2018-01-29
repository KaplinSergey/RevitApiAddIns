using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Applications.AreaCalculator.Model
{
  public class CalculatorViewModel
  {

    public void CalculateRoomArea(UIDocument uidoc)
    {
      Document currentDocument = uidoc.Document;
      IEnumerable<Element> allRoomElements = new FilteredElementCollector(currentDocument).OfCategory(BuiltInCategory.OST_Rooms).ToElements();


      IEnumerable<RoomElement> rooms = allRoomElements.Select(e => e as Room).Select(r => new RoomElement(r));

      RoomsService service = new RoomsService();
      IEnumerable<Apartament> apartments = null;
      try
      {
        apartments = service.GetApartments(rooms);
      }
      catch (Exception ex)
      {
        TaskDialog.Show("Error", ex.Message);
      }

      try
      {
        using (Transaction currentTransaction = new Transaction(currentDocument))
        {
          currentTransaction.Start("Change apartments");

          service.UpdateApartments(apartments);

          currentDocument.Regenerate();
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
