using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();

            Console.Write("Pickup (dd/MM/yyyy hh:ss): ");
            DateTime start = DateTime.Parse(Console.ReadLine());

            Console.Write("Return (dd/MM/yyyy hh:ss): ");
            DateTime finish = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine());

            Console.Write("Enter price per day: ");
            double day = int.Parse(Console.ReadLine());

            CarRental obj_CarRental = new CarRental(start,finish, new Vehicle(model));

            RentalService obj_RentalService = new RentalService(hour,day, new BrazilTaxService());

            obj_RentalService.ProcessInvoice(obj_CarRental);

            Console.WriteLine("INVOICE");

            Console.WriteLine(obj_CarRental.Invoice);
            Console.ReadLine();
        }
    }
}
