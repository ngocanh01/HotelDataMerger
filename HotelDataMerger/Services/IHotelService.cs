using HotelDataMerger.Models;

namespace HotelDataMerger.Services
{
	public interface IHotelService
	{
		Task<List<Hotel>> GetHotelDataAsync();
		List<Hotel> FilterHotels(List<Hotel> hotels, List<string> hotelIds, List<int> destinationIds);
		List<Hotel> MergeHotelListsWithFullData(List<Hotel> hotels);
	}
}
