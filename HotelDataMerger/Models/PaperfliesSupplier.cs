using System.Text.Json.Serialization;

namespace HotelDataMerger.Models
{
	public class PaperfliesSupplier
	{
		[JsonPropertyName("hotel_id")]
		public string HotelId { get; set; }

		[JsonPropertyName("destination_id")]
		public int DestinationId { get; set; }

		[JsonPropertyName("hotel_name")]
		public string HotelName { get; set; }

		public LocationInfo Location { get; set; }
		public string Details { get; set; }
		public AmenitiesInfo Amenities { get; set; }
		public ImagesInfo Images { get; set; }

		[JsonPropertyName("booking_conditions")]
		public List<string> BookingConditions { get; set; }

		public class LocationInfo
		{
			public string Address { get; set; }
			public string Country { get; set; }
		}

		public class AmenitiesInfo
		{
			public List<string> General { get; set; }
			public List<string> Room { get; set; }
		}

		public class ImageInfo
		{
			public string Link { get; set; }
			public string Caption { get; set; }
		}

		public class ImagesInfo
		{
			public List<ImageInfo> Rooms { get; set; }
			public List<ImageInfo> Site { get; set; }
		}
	}
}
