using Rezerwacje.NET.Data;
using Rezerwacje.NET.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rezerwacje.NET.ViewModel.ViewObjects
{
    public class RoomViewObject : ViewObject
    {
        private Room _room;

        public RoomViewObject(Room room = null)
        {
            if (room != null)
                _room = room;
            else
                _room = new Room();
        }

        public int RoomNumber { 
            get 
            { 
                return (int)(_room?.RoomNumber); 
            } 
            set 
            {
                if(_room != null) _room.RoomNumber = value ;
            }
        }

        public int Floor {
            get
            {
                return (int)(_room?.Floor);
            }
            set
            {
                if (_room != null) _room.Floor = value;
            }
        }

        public string Type {
            get
            {
                return _room?.Type;
            }
            set
            {
                if (_room != null) _room.Type = value;
            }
        }

        public int? SurfaceArea
        {
            get
            {
                return (int)(_room?.SurfaceArea);
            }
            set
            {
                if (_room != null) _room.SurfaceArea = value;
            }
        }

        public int? GuestsAmount
        {
            get
            {
                return (int)(_room?.GuestsAmount);
            }
            set
            {
                if (_room != null) _room.GuestsAmount = value;
            }
        }

        public decimal? PricePerNight {
            get
            {
                return (decimal)(_room?.PricePerNight);
            }
            set
            {
                if (_room != null) _room.PricePerNight = value;
            }
        }

        public void AddToDatabase(DbReservationsContext context)
        {
            context.Add<Room>(_room);
            context.SaveChanges();
        }

        public void SaveChangesToDatabase(DbReservationsContext context)
        {
            context.SaveChanges();
        }

        public void RemoveFromDatabase(DbReservationsContext context)
        {
            context.Remove<Room>(_room);
            context.SaveChanges();
        }
    }
}
