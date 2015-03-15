using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareDevice
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
}