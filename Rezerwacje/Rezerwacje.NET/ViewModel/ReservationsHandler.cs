using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rezerwacje.NET.ViewModel
{
    public class ReservationsHandler
    {
        private ReservationViewObject _reservation;

        public ReservationsHandler(ReservationViewObject reservation)
        {
            _reservation = reservation;
        }


        public void AddReservation(Room room, Guest guest, DateTime startDate, DateTime endDate)
        {
            if (!ValidateReservationDate(startDate, endDate, true)) return;
            if (!CheckRoomAvailablity(room, startDate, endDate, true)) return;


        }
        

        private bool ValidateReservationDate(DateTime startDate, DateTime endDate, bool showMessages=false)
        {
            if (endDate <= startDate)
            { 
                if (showMessages) WindowManager.ShowPopupMessage("Reservation due date is too early.");
                return false;
            }
            
            return true;
        }

        private bool CheckRoomAvailablity(Room room, DateTime startDate, DateTime endDate, bool showMessages = false)
        {
            if (showMessages) WindowManager.ShowPopupMessage("Room isn't available at given date.");

            return true;
        }
    }
}
