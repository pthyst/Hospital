using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.ViewModels
{
    public class AdminRoomsViewModel
    {
        public Room Room {get; set;}
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<Room> Rooms {get;set;}
    }
}
