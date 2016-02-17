using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareItemUpdate
	{
		[JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "category_id")]
        public string CategoryId { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty(PropertyName = "visibility")]
        public string Visibility { get; set; }

        [JsonProperty(PropertyName = "available_online")]
        public bool AvailableOnline { get; set; }

        [JsonProperty(PropertyName = "available_for_pickup")]
        public bool AvailableForPickup { get; set; }
	}


}
