using System;
using System.Collections.Generic;

namespace Rezerwacje.NET.Model
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public int? GuestId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public virtual Guest Guest { get; set; }
        public virtual Room RoomNumberNavigation { get; set; }
    }
}
