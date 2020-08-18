using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rezerwacje.NET.ViewModel.ViewObjects
{
    public class ReservationViewObject : ViewObject
    {
        private Reservation _reservation;

        public ReservationViewObject(Reservation reservation = null)
        {
            if (reservation != null)
                _reservation = reservation;
            else
                _reservation = new Reservation();
        }

        public int Id
        {
            get
            {
                return (int)(_reservation?.Id);
            }
            set
            {
                if (_reservation != null) _reservation.Id = value;
            }
        }

        public DateTime? From { 
            get {
                return _reservation?.From;
            }
            set {
                if(_reservation != null) _reservation.From = value;
            }
        }

        public DateTime? To {
            get
            {
                return _reservation?.To;
            }
            set
            {
                if (_reservation != null) _reservation.To = value;
            }
        }

        public int? RoomNumber
        {
            get
            {
                return _reservation?.RoomNumber;
            }
            set
            {
                if (_reservation != null) _reservation.RoomNumber = value;
            }
        }

        public int Floor
        {
            get
            {
                return (int)(_reservation?.RoomNumberNavigation?.Floor);
            }
        }

        public string RoomType
        {
            get
            {
                return _reservation?.RoomNumberNavigation?.Type;
            }
        }

        public int RoomSurface
        {
            get
            {
                return (int)(_reservation?.RoomNumberNavigation?.SurfaceArea);
            }
        }

        public int GuestsAmount
        {
            get
            {
                return (int)(_reservation?.RoomNumberNavigation?.GuestsAmount);
            }
        }

        public decimal RoomPrice
        {
            get
            {
                return (decimal)(_reservation?.RoomNumberNavigation?.PricePerNight);
            }
        }

        public string GuestName {
            get
            {
                return _reservation?.Guest?.Name;
            }
        }
        public string GuestSurname {
            get
            {
                return _reservation?.Guest?.Surname;
            }
        }
        public string GuestEmail {
            get
            {
                return _reservation?.Guest?.Email;
            }
        }
        public string GuestPhone {
            get {
                return _reservation?.Guest?.Phone;
            }
        }


        public void setGuest(int guestID)
        {
            _reservation.GuestId = guestID;
        }

        public void setRoom(int roomNumber)
        {
            _reservation.RoomNumber = roomNumber;
        }


        public void AddToDatabase(DbReservationsContext context)
        {
            context.Add<Reservation>(_reservation);
            context.SaveChanges();
        }

        public void SaveChangesToDatabase(DbReservationsContext context)
        {
            context.SaveChanges();
        }

        public void RemoveFromDatabase(DbReservationsContext context)
        {
            context.Remove<Reservation>(_reservation);
            context.SaveChanges();
        }
    }
}
