using HotelDataMerger.Models;

namespace HotelDataMerger.Mappers
{
    public class PatagoniaMapper
	{
		public static Hotel MapToHotelResponse(PatagoniaSupplier patagoniaSupplier)
		{
			var hotelResponse = new Hotel
			{
				Id = patagoniaSupplier.Id,
				DestinationId = patagoniaSupplier.Destination,
				Name = patagoniaSupplier.Name,
				Location = new Location
				{
					Lat = patagoniaSupplier.Lat,
					Lng = patagoniaSupplier.Lng,
					Address = patagoniaSupplier.Address,
					City = "", // You can set this value if available
					Country = "", // You can set this value if available
				},
				Description = patagoniaSupplier.Info,
				Amenities = new Amenities
				{
					General = patagoniaSupplier.Amenities,
					Room = new List<string>()
				},
				Images = new Images
				{
					Rooms = MapImages(patagoniaSupplier.Images.Rooms),
					Site = new List<ImageInfo>(),
					Amenities = MapImages(patagoniaSupplier.Images.Amenities)
				},
				BookingConditions = new List<string>()
			};

			return hotelResponse;
		}

		private static List<ImageInfo> MapImages(List<PatagoniaSupplier.Image> patagoniaImages)
		{
			return patagoniaImages?.Select(image => new ImageInfo
			{
				Link = image.Url,
				Description = image.Description
			}).ToList() ?? new List<ImageInfo>();
		}

		public static List<Hotel> MapToHotelResponseList(List<PatagoniaSupplier> patagoniaSuppliers)
		{
			return patagoniaSuppliers.Select(MapToHotelResponse).ToList();
		}
	}
}
