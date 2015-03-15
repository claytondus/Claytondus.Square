using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareMoney
	{
		[JsonProperty(PropertyName = "amount")]
		public int Amount { get; set; }

		[JsonProperty(PropertyName = "currency_code")]
		public string CurrencyCode { get; set; }
	}
}