using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rezerwacje.NET.ViewModel.ViewObjects
{
    public class GuestViewObject : ViewObject
    {
        private Guest _guest;

        public GuestViewObject(Guest guest = null)
        {
            if (guest != null)
                _guest = guest;
            else
                _guest = new Guest();
        }

        public int Id {
            get
            {
                return (int)(_guest?.Id);
            }
            set
            {
                if (_guest != null) _guest.Id = value;
            }
        }

        public string Name
        {
            get
            {
                return _guest?.Name;
            }
            set
            {
                if (_guest != null) _guest.Name = value;
            }
        }
        public string Surname {
            get
            {
                return _guest?.Surname;
            }
            set
            {
                if (_guest != null) _guest.Surname = value;
            }
        }
        public string Email {
            get
            {
                return _guest?.Email;
            }
            set
            {
                if (_guest != null) _guest.Email = value;
            }
        }
        public string Phone {
            get
            {
                return _guest?.Phone;
            }
            set
            {
                if (_guest != null) _guest.Phone = value;
            }
        }

        public void AddToDatabase(DbReservationsContext context)
        {
            context.Add<Guest>(_guest);
            context.SaveChanges();
        }

        public void SaveChangesToDatabase(DbReservationsContext context)
        {
            context.SaveChanges();
        }

        public void RemoveFromDatabase(DbReservationsContext context)
        {
            context.Remove<Guest>(_guest);
            context.SaveChanges();
        }
    }
}
