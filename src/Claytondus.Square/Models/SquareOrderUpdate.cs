using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
    /// <summary>
    /// Input model for updating an order
    /// </summary>
    public class SquareOrderUpdate
    {
        /// <summary>
        /// The action to perform on the order: One of COMPLETE, CANCEL, or REFUND
        /// </summary>
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
