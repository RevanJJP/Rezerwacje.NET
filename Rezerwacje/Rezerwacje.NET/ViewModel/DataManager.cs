using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel.ViewObjects;

namespace Rezerwacje.NET.ViewModel
{
    public class DataManager
    {

        private DbReservationsContext _ctx;

        public DataManager()
        {
            _ctx = new DbReservationsContext();
        }


        public DbReservationsContext Context
        {
            get
            {
                return _ctx;
            }
        }


        public List<ReservationViewObject> Reservations
        {
            get { 
                List<Reservation> reservationList = _ctx.Reservation.ToList();
                List<ReservationViewObject> reservationViewList = new List<ReservationViewObject>();

                foreach(Reservation reservation in reservationList)
                {
                    reservationViewList.Add(new ReservationViewObject(reservation));
                }

                return reservationViewList;
            }
        }

        public List<RoomViewObject> Rooms
        {
            get
            {
                List<Room> roomList = _ctx.Room.ToList();
                List<RoomViewObject> roomViewList = new List<RoomViewObject>();

                foreach (Room room in roomList)
                {
                    roomViewList.Add(new RoomViewObject(room));
                }

                return roomViewList;
            }
        }

        public List<GuestViewObject> Guests
        {
            get
            {
                List<Guest> guestList = _ctx.Guest.ToList();
                List<GuestViewObject> guestViewList = new List<GuestViewObject>();

                foreach (Guest guest in guestList)
                {
                    guestViewList.Add(new GuestViewObject(guest));
                }

                return guestViewList;
            }
        }

    }
}
