using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquarePaymentDiscount
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "applied_money")]
		public SquareMoney AppliedMoney { get; set; }

		[JsonProperty(PropertyName = "discount_id")]
		public string DiscountId { get; set; }
	}
}