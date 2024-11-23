namespace HotelDataMerger.Models
{
	public class Hotel
	{
		public string Id { get; set; }
		public int DestinationId { get; set; }
		public string Name { get; set; }
		public Location Location { get; set; }
		public string Description { get; set; }
		public Amenities Amenities { get; set; }
		public Images Images { get; set; }
		public List<string> BookingConditions { get; set; }
	}
	public class Amenities
	{
		public List<string> General { get; set; }
		public List<string> Room { get; set; }
	}

	public class ImageInfo
	{
		public string Link { get; set; }
		public string Description { get; set; }
	}

	public class Images
	{
		public List<ImageInfo> Rooms { get; set; }
		public List<ImageInfo> Site { get; set; }
		public List<ImageInfo> Amenities { get; set; }
	}

	public class Location
	{
		public double Lat { get; set; }
		public double Lng { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
