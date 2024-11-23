using HotelDataMerger.Models;

namespace HotelDataMerger.Mappers
{
    public class PaperfliesMapper
	{
		public static Hotel MapToHotelResponse(PaperfliesSupplier paperfliesSupplier)
		{
			return new Hotel
			{
				Id = paperfliesSupplier.HotelId,
				DestinationId = paperfliesSupplier.DestinationId,
				Name = paperfliesSupplier.HotelName,
				Location = new Location
				{
					Address = paperfliesSupplier.Location?.Address,
					Country = paperfliesSupplier.Location?.Country,
					Lat = 0.0, // You might need to retrieve or calculate latitude here
					Lng = 0.0, // You might need to retrieve or calculate longitude here
					City = ""  // Populate this if city information is available
				},
				Description = paperfliesSupplier.Details,
				Amenities = new Amenities
				{
					General = paperfliesSupplier.Amenities?.General,
					Room = paperfliesSupplier.Amenities?.Room
				},
				Images = new Images
				{
					Rooms = paperfliesSupplier.Images?.Rooms?.ConvertAll(img => new ImageInfo
					{
						Link = img.Link,
						Description = img.Caption
					}),
					Site = paperfliesSupplier.Images?.Site?.ConvertAll(img => new ImageInfo
					{
						Link = img.Link,
						Description = img.Caption
					}),
					Amenities = new List<ImageInfo>() // Adjust if there are any Amenities images
				},
				BookingConditions = paperfliesSupplier.BookingConditions
			};
		}

		public static List<Hotel> MapToHotelResponseList(List<PaperfliesSupplier> paperfliesSuppliers)
		{
			return paperfliesSuppliers.Select(MapToHotelResponse).ToList();
		}
	}
}
