using HotelDataMerger.Models;

namespace HotelDataMerger
{
	public class DataMerger
	{
		public List<Hotel> MergeHotelListsWithFullData(List<Hotel> list1, List<Hotel> list2, List<Hotel> list3)
		{
			// Concatenate all lists and group by unique hotel Id
			var mergedHotels = list1
				.Concat(list2)
				.Concat(list3)
				.GroupBy(hotel => hotel.Id)
				.Select(group => MergeHotelGroup(group))
				.ToList();

			return mergedHotels;
		}

		private Hotel MergeHotelGroup(IGrouping<string, Hotel> hotelGroup)
		{
			var mergedHotel = new Hotel
			{
				Id = hotelGroup.Key,
				DestinationId = hotelGroup.Select(h => h.DestinationId).FirstOrDefault(d => d != 0),
				Name = hotelGroup.Select(h => h.Name).FirstOrDefault(name => !string.IsNullOrEmpty(name)),
				Location = MergeLocations(hotelGroup.Select(h => h.Location).Where(loc => loc != null)),
				Description = hotelGroup.Select(h => h.Description).FirstOrDefault(desc => !string.IsNullOrEmpty(desc)),
				Amenities = MergeAmenities(hotelGroup.Select(h => h.Amenities).Where(amenities => amenities != null)),
				Images = MergeImages(hotelGroup.Select(h => h.Images).Where(images => images != null)),
				BookingConditions = hotelGroup.SelectMany(h => h.BookingConditions ?? new List<string>()).Distinct().ToList()
			};

			return mergedHotel;
		}

		private Location MergeLocations(IEnumerable<Location> locations)
		{
			return new Location
			{
				Lat = locations.Select(loc => loc.Lat).FirstOrDefault(lat => lat != 0),
				Lng = locations.Select(loc => loc.Lng).FirstOrDefault(lng => lng != 0),
				Address = locations.Select(loc => loc.Address).FirstOrDefault(addr => !string.IsNullOrEmpty(addr)),
				City = locations.Select(loc => loc.City).FirstOrDefault(city => !string.IsNullOrEmpty(city)),
				Country = locations.Select(loc => loc.Country).FirstOrDefault(country => !string.IsNullOrEmpty(country))
			};
		}

		private Amenities MergeAmenities(IEnumerable<Amenities> amenitiesList)
		{
			return new Amenities
			{
				General = amenitiesList.SelectMany(a => a.General ?? new List<string>()).Distinct().ToList(),
				Room = amenitiesList.SelectMany(a => a.Room ?? new List<string>()).Distinct().ToList()
			};
		}

		private Images MergeImages(IEnumerable<Images> imagesList)
		{
			return new Images
			{
				Rooms = imagesList.SelectMany(img => img.Rooms ?? new List<ImageInfo>()).DistinctBy(i => i.Link).ToList(),
				Site = imagesList.SelectMany(img => img.Site ?? new List<ImageInfo>()).DistinctBy(i => i.Link).ToList(),
				Amenities = imagesList.SelectMany(img => img.Amenities ?? new List<ImageInfo>()).DistinctBy(i => i.Link).ToList()
			};
		}
	}
}
