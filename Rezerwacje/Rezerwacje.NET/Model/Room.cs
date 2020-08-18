using System;
using System.Collections.Generic;

namespace Rezerwacje.NET.Model
{
    public partial class Room
    {
        public Room()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
        public int? SurfaceArea { get; set; }
        public int? GuestsAmount { get; set; }
        public decimal? PricePerNight { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
