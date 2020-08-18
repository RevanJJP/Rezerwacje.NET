using System;
using System.Collections.Generic;

namespace Rezerwacje.NET.Model
{
    public partial class Guest
    {
        public Guest()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
