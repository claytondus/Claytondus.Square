using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquarePaymentTax
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "applied_money")]
		public SquareMoney AppliedMoney { get; set; }

		[JsonProperty(PropertyName = "rate")]
		public decimal Rate { get; set; }

		[JsonProperty(PropertyName = "inclusion_type")]
		public string InclusionType { get; set; }

		[JsonProperty(PropertyName = "fee_id")]
		public string FeeId { get; set; }
	}
}