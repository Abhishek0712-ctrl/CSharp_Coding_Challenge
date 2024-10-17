using EntityPackage;
using DAOPackage;
namespace HelperPackage
{
    public class HelperClass
    {
        AdoptionEvent ev = new AdoptionEvent();
        public  void displayPet()
        {
            Console.WriteLine("Pets data: ");
            ev.ShowPet();
        }



    }
}
