using System;
using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareOrderHistory
	{
		[JsonProperty(PropertyName = "action")]
		public string Action { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset CreatedAt { get; set; }
	}
}