using Rezerwacje.NET.Data;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rezerwacje.NET.ViewModel
{
    public class GuestValidator
    {
        private DbReservationsContext _ctx;

        public GuestValidator(DbReservationsContext context)
        {
            _ctx = context;
        }

        public bool ValidateGuest(GuestViewObject guest, bool showMessages = false)
        {
            if(guest.Name == null || guest.Name.Length == 0)
            {
                if (showMessages) WindowManager.ShowPopupMessage("Name cannot be empty");
                return false;
            }

            if (guest.Surname == null || guest.Surname.Length == 0)
            {
                if (showMessages) WindowManager.ShowPopupMessage("Surname cannot be empty");
                return false;
            }

            return true;
        }
    }
}
