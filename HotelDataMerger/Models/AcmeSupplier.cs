using HotelDataMerger.Converter;
using System.Text.Json.Serialization;

namespace HotelDataMerger.Models
{
	public class AcmeSupplier : BaseSupplier
	{
		[JsonPropertyName("Id")]
		public string Id { get; set; }
		[JsonPropertyName("DestinationId")]
		public int DestinationId { get; set; }
		[JsonPropertyName("Name")]
		public string Name { get; set; }
		[JsonPropertyName("Latitude")]
		[JsonConverter(typeof(NullableDoubleConverter))]
		public double? Latitude { get; set; }
		[JsonPropertyName("Longitude")]
		[JsonConverter(typeof(NullableDoubleConverter))]
		public double? Longitude { get; set; }
		[JsonPropertyName("Address")]
		public string Address { get; set; }
		[JsonPropertyName("City")]
		public string City { get; set; }
		[JsonPropertyName("Country")]
		public string Country { get; set; }
		[JsonPropertyName("PostalCode")]
		public string PostalCode { get; set; }
		[JsonPropertyName("Description")]
		public string Description { get; set; }
		[JsonPropertyName("Facilities")]
		public List<string> Facilities { get; set; }

	}
}
