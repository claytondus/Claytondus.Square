using Flurl;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareTender
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "receipt_url")]
		public Url ReceiptUrl { get; set; }

		[JsonProperty(PropertyName = "card_brand")]
		public string CardBrand { get; set; }

		[JsonProperty(PropertyName = "pan_suffix")]
		public string PanSuffix { get; set; }

		[JsonProperty(PropertyName = "entry_method")]
		public string EntryMethod { get; set; }

		[JsonProperty(PropertyName = "payment_note")]
		public string PaymentNote { get; set; }

		[JsonProperty(PropertyName = "total_money")]
		public SquareMoney TotalMoney { get; set; }

		[JsonProperty(PropertyName = "tendered_money")]
		public SquareMoney TenderedsMoney { get; set; }

		[JsonProperty(PropertyName = "charge_back_money")]
		public SquareMoney ChargeBackMoney { get; set; }

		[JsonProperty(PropertyName = "refunded_money")]
		public SquareMoney RefundedMoney { get; set; }


	}
}