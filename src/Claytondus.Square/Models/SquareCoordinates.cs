using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareCoordinates
	{
		[JsonProperty(PropertyName = "latitude")]
		public decimal Latitude { get; set; }

		[JsonProperty(PropertyName = "longitude")]
		public decimal Longitude { get; set; }
	}
}