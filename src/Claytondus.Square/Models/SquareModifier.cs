using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareModifier
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "applied_money")]
		public SquareMoney AppliedMoney { get; set; }

		[JsonProperty(PropertyName = "modifier_option_id")]
		public string ModifierOptionId { get; set; }
	}
}