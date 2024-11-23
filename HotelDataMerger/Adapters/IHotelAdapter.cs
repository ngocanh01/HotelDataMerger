using HotelDataMerger.Models;

namespace HotelDataMerger.Adapters
{
	public interface IHotelAdapter
	{
		Task<List<Hotel>> ConvertToHotel(string rawData);
	}
}
