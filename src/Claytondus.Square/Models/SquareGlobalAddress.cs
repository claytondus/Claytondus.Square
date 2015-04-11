using Newtonsoft.Json;

namespace Claytondus.Square.Models
{
	public class SquareGlobalAddress
	{
		[JsonProperty(PropertyName = "address_line_1")]
		public string AddressLine1 { get; set; }

		[JsonProperty(PropertyName = "address_line_2")]
		public string AddressLine2 { get; set; }

		[JsonProperty(PropertyName = "address_line_3")]
		public string AddressLine3 { get; set; }

		[JsonProperty(PropertyName = "address_line_4")]
		public string AddressLine4 { get; set; }

		[JsonProperty(PropertyName = "address_line_5")]
		public string AddressLine5 { get; set; }

		[JsonProperty(PropertyName = "locality")]
		public string Locality { get; set; }

		[JsonProperty(PropertyName = "sublocality")]
		public string Sublocality { get; set; }

		[JsonProperty(PropertyName = "sublocality_1")]
		public string Sublocality1 { get; set; }

		[JsonProperty(PropertyName = "sublocality_2")]
		public string Sublocality2 { get; set; }

		[JsonProperty(PropertyName = "sublocality_3")]
		public string Sublocality3 { get; set; }

		[JsonProperty(PropertyName = "sublocality_4")]
		public string Sublocality4 { get; set; }

		[JsonProperty(PropertyName = "sublocality_5")]
		public string Sublocality5 { get; set; }

		[JsonProperty(PropertyName = "administrative_district_level_1")]
		public string AdminDistrict1 { get; set; }

		[JsonProperty(PropertyName = "administrative_district_level_2")]
		public string AdminDistrict2 { get; set; }

		[JsonProperty(PropertyName = "administrative_district_level_3")]
		public string AdminDistrict3 { get; set; }

		[JsonProperty(PropertyName = "postal_code")]
		public string PostalCode { get; set; }

		[JsonProperty(PropertyName = "country_code")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "address_coordinates")]
		public SquareCoordinates Coordinates { get; set; }

	}
}