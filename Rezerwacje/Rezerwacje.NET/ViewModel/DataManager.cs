using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel.ViewObjects;

namespace Rezerwacje.NET.ViewModel
{
    public class DataManager
    {
        private DbReservationsContext _ctx;
        private ReservationValidator _reservationValidator;
        private GuestValidator _guestValidator;

        public DataManager()
        {
            _ctx = new DbReservationsContext();
            _reservationValidator = new ReservationValidator(_ctx);
            _guestValidator = new GuestValidator(_ctx);
        }


        public DbReservationsContext Context
        {
            get
            {
                return _ctx;
            }
        }

        public ReservationValidator ReservationValidator {
            get { 
                return _reservationValidator; 
            } 
        }

        public GuestValidator GuestValidator
        {
            get
            {
                return _guestValidator;
            }
        }

        public ReservationViewObject GetReservation(int Id)
        {
            Reservation reservation = _ctx.Reservation.Find(Id);
            return new ReservationViewObject(reservation);
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

        public RoomViewObject GetRoom(int roomNumber)
        {
            Room room = _ctx.Room.Find(roomNumber);
            return new RoomViewObject(room);
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

        public GuestViewObject GetGuest(int Id)
        {
            Guest guest = _ctx.Guest.Find(Id);
            return new GuestViewObject(guest);
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

        public void Update()
        {
            //Trying to bypass lazy loading, which causes virtual data to be null
            _ctx.Reservation.Load();
            _ctx.Guest.Load();
            _ctx.Room.Load();
        }

    }
}
