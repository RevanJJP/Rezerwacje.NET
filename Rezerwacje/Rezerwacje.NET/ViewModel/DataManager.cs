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

    }
}
