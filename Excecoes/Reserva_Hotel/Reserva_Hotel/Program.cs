using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());


                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                //Reserva o hotel
                Reservation obj_Reservation = new Reservation(number, checkIn, checkOut);

                //Escreve os dados da reserva
                Console.WriteLine(obj_Reservation.ToString());

                //Formulario para atualizar a reserva
                Console.WriteLine("Enter data to update the reservation");

                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                //Atualiza a reserva
                obj_Reservation.UpdateDates(checkIn, checkOut);
                Console.WriteLine(obj_Reservation.ToString());
            }
            catch (DomainExceptions message)
            {
                Console.WriteLine("Error: {0}", message.Message);

            }
            catch (FormatException)
            {
                Console.WriteLine("A informação inserida não pode ser um carac");
            }
            Console.ReadLine();
        }
    }
}
