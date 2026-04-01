using System.Text.Json.Serialization;

namespace RAPIDAPI_CONSUME.Models
{
    public class BookingcomModel
    {
        [JsonPropertyName("timeSlotId")]
        public string? TimeSlotId { get; set; }

        [JsonPropertyName("fullDay")]
        public bool FullDay { get; set; }

        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("timeSlotOffers")]
        public List<TimeSlotOffer>? TimeSlotOffers { get; set; }

        [JsonPropertyName("applicableTerms")]
        public object? ApplicableTerms { get; set; }
    }

    public class TimeSlotOffer
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("items")]
        public List<BookingItem>? Items { get; set; }
    }

    public class BookingItem
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("price")]
        public BookingPrice? Price { get; set; }
    }

    public class BookingPrice
    {
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("publicAmount")]
        public decimal PublicAmount { get; set; }
    }
}
