using System;
using System.Collections.Generic;
using System.Text;

namespace API.EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingID { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string? AdultCount { get; set; }

        public string? ChildCount { get; set; }

        public string? RoomCount { get; set; }

        public string? SpecialReq { get; set; }

        public string? Status { get; set; }

    }
}
