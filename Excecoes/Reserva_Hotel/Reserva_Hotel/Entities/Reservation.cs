using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva_Hotel
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn {  get; set; }
        public DateTime CheckOut {  get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainExceptions("Check-out date must be after check-in date"); //data de entrada deve ser maior que data de saida
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        //Calcula a duração em dias do tempo da reserva
        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if(checkIn < now)
            {
                throw new DomainExceptions("Reservation dates for updates must be future dates"); //As datas de reserva para atualizações devem ser datas futuras
            }

            if(checkOut <= checkIn)
            {
                throw new DomainExceptions("Check-out date must be after check-in date");//data de entrada deve ser maior que data de saida
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "\nRoom: " + RoomNumber + " checkin: " + CheckIn.ToString("dd/MM/yyyy") 
                + " checkout: " + CheckOut.ToString("dd/MM/yyyy") + " Duration: " + Duration() + " nights";
        }
    }
}
