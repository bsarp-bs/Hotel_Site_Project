using System;
using System.Collections.Generic;
using System.Text;

namespace API.EntityLayer.Concrete
{
    public class Room
    {
        public int RoomID { get; set; }
        public string No { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int BedCount { get; set; }
        public string Desc { get; set; }
    
    }
}
