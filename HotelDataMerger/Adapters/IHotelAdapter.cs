using HotelDataMerger.Models;

namespace HotelDataMerger.Adapters
{
	public interface IHotelAdapter
	{
		ApiName ApiName { get; }
		Task<List<Hotel>> ConvertToHotelAsync();
	}
}
