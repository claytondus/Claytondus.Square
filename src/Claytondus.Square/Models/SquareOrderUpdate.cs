using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
    public class SquareOrderUpdate
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "shipped_tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "completed_note")]
        public string CompletedNote { get; set; }

        [JsonProperty(PropertyName = "refunded_note")]
        public string RefundedNote { get; set; }

        [JsonProperty(PropertyName = "canceled_note")]
        public string CanceledNote { get; set; }
    }
}
