using System.Text.Json.Serialization;

namespace HotelDataMerger.Models
{
	public class PatagoniaSupplier : BaseSupplier
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("destination")]
		public int Destination { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		[JsonPropertyName("lng")]
		public double Lng { get; set; }

		[JsonPropertyName("address")]
		public string Address { get; set; }

		[JsonPropertyName("info")]
		public string Info { get; set; }

		[JsonPropertyName("amenities")]
		public List<string> Amenities { get; set; }

		[JsonPropertyName("images")]
		public ImageGroup Images { get; set; }

		public class Image
		{
			[JsonPropertyName("url")]
			public string Url { get; set; }

			[JsonPropertyName("description")]
			public string Description { get; set; }
		}

		public class ImageGroup
		{
			[JsonPropertyName("rooms")]
			public List<Image> Rooms { get; set; }

			[JsonPropertyName("amenities")]
			public List<Image> Amenities { get; set; }
		}
	}
}
