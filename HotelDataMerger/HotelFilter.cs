using HotelDataMerger.Models;

namespace HotelDataMerger
{
	public class HotelFilter
	{
		public List<Hotel> FilterHotels(List<Hotel> hotels, List<string> hotelIds, List<int> destinationIds)
		{
			if (destinationIds == null && destinationIds == null)
			{
				return hotels.OrderBy(hotel => hotel.DestinationId).ToList();
			}

			if (hotelIds == null || destinationIds == null)
			{
				return new List<Hotel>();
			}		

			return hotels.Where(hotel => hotelIds.Contains(hotel.Id) &&	destinationIds.Contains(hotel.DestinationId)).OrderBy(hotel => hotel.DestinationId).ToList();
		}
	}
}
