using HotelDataMerger.Models;

namespace HotelDataMerger.Mappers
{
    public static class AcmeMapper
	{
		public static Hotel MapToHotelResponse(AcmeSupplier acmeSupplier)
		{
			var hotelResponse = new Hotel
			{
				Id = acmeSupplier.Id,
				DestinationId = acmeSupplier.DestinationId,
				Name = acmeSupplier.Name,
				Location = new Location
				{
					Lat = acmeSupplier.Latitude ?? 0, // Fallback to 0 if Latitude is null
					Lng = acmeSupplier.Longitude ?? 0, // Fallback to 0 if Longitude is null
					Address = acmeSupplier.Address,
					City = acmeSupplier.City,
					Country = acmeSupplier.Country
				},
				Description = acmeSupplier.Description,
				Amenities = new Amenities
				{
					General = acmeSupplier.Facilities.Where(f => !f.StartsWith("Room")).ToList(),
					Room = acmeSupplier.Facilities.Where(f => f.StartsWith("Room")).ToList()
				},
				Images = new Images
				{
					Rooms = new List<ImageInfo>(),
					Site = new List<ImageInfo>(),
					Amenities = new List<ImageInfo>()
				},
				BookingConditions = new List<string>()
			};

			return hotelResponse;
		}

		public static List<Hotel> MapToHotelResponseList(List<AcmeSupplier> acmeSuppliers)
		{
			return acmeSuppliers.Select(hotel => MapToHotelResponse(hotel)).ToList();
		}
	}
}
