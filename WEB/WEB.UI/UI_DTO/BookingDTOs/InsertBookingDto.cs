namespace WEB_UI.UI_DTO.BookingDTOs
{
    public class InsertBookingDto
    {
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
