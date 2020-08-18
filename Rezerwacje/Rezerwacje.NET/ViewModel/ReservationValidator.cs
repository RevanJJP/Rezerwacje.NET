using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rezerwacje.NET.ViewModel
{
    public class ReservationValidator
    {
        private DbReservationsContext _ctx;

        public ReservationValidator(DbReservationsContext context)
        {
            _ctx = context;
        }


        public bool ValidateReservation(ReservationViewObject reservation, bool showMessages=false)
        {
            if (!ValidateReservationDate((DateTime)reservation.From, (DateTime)reservation.To, showMessages)) return false;
            if (!CheckRoomAvailablity((int)reservation.RoomNumber, (DateTime)reservation.From, (DateTime)reservation.To, true)) return false;

            return true;
        }
        

        private bool ValidateReservationDate(DateTime startDate, DateTime endDate, bool showMessages=false)
        {
            if (endDate == null || startDate == null)
            {
                if (showMessages) WindowManager.ShowPopupMessage("Dates cannot be empty.");
                return false;
            }

            if (endDate <= startDate)
            { 
                if (showMessages) WindowManager.ShowPopupMessage("Reservation due date is too early.");
                return false;
            }
            
            return true;
        }

        private bool CheckRoomAvailablity(int roomNumber, DateTime startDate, DateTime endDate, bool showMessages = false)
        {
            var output = _ctx.Reservation.Where(r => (r.RoomNumber == roomNumber) &&
                                                        ((r.From > startDate) && (r.From < endDate)
                                                        || ((r.To > startDate) && (r.To < endDate))
                                                        || ((r.From == startDate) && (r.To == endDate))
                                                        )
                                                        ).ToArray();

            WindowManager.ShowPopupMessage(output.Length.ToString());


            if (output == null)
            {
                WindowManager.ShowPopupMessage("NONE FOUND");
                return true;
            }
            else
            {
                if (showMessages) WindowManager.ShowPopupMessage("Room isn't available at given date.");
                return false; 
            }
        }
    }
}
