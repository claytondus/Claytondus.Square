using System;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareRefund
	{
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "reason")]
		public string Reason { get; set; }

		[JsonProperty(PropertyName = "refunded_money")]
		public SquareMoney RefundedMoney { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonProperty(PropertyName = "processed_at")]
		public DateTimeOffset ProcessedAt { get; set; }

		[JsonProperty(PropertyName = "payment_id")]
		public string PaymentId { get; set; }

        [JsonProperty(PropertyName = "request_idempotence_key")]
        public string RequestIdempotenceKey { get; set; }
	}
}