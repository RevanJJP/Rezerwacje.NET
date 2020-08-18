using Rezerwacje.NET.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rezerwacje.NET.ViewModel
{
    interface ViewObject
    {
        public void AddToDatabase(DbReservationsContext context);

        public void SaveChangesToDatabase(DbReservationsContext context);

        public void RemoveFromDatabase(DbReservationsContext context);
    }
}
