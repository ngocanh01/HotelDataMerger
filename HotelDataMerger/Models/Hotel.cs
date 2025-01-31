﻿using System.Text.Json.Serialization;

namespace HotelDataMerger.Models
{
	public class Hotel
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("destination_id")]
		public int DestinationId { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("location")]
		public Location Location { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; } 

		[JsonPropertyName("amenities")]
		public Amenities Amenities { get; set; }

		[JsonPropertyName("images")]
		public Images Images { get; set; }

		[JsonPropertyName("booking_conditions")]
		public List<string> BookingConditions { get; set; }
	}

	public class Amenities
	{
		[JsonPropertyName("general")]
		public List<string> General { get; set; }

		[JsonPropertyName("room")]
		public List<string> Room { get; set; }
	}

	public class ImageInfo
	{
		[JsonPropertyName("link")]
		public string Link { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }
	}

	public class Images
	{
		[JsonPropertyName("rooms")]
		public List<ImageInfo> Rooms { get; set; }

		[JsonPropertyName("site")]
		public List<ImageInfo> Site { get; set; }

		[JsonPropertyName("amenities")]
		public List<ImageInfo> Amenities { get; set; }
	}

	public class Location
	{
		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		[JsonPropertyName("lng")]
		public double Lng { get; set; }

		[JsonPropertyName("address")]
		public string Address { get; set; }

		[JsonPropertyName("city")]
		public string City { get; set; }

		[JsonPropertyName("country")]
		public string Country { get; set; }
	}
}
