using HotelDataMerger.Adapters;
using HotelDataMerger.Factories;
using HotelDataMerger.Models;
using HotelDataMerger.Parsers;

namespace HotelDataMerger.Services
{
	public class HotelService
	{
		public async Task<List<Hotel>> GetHotelData(string url, string suppliername)
		{
			IDataParser parser = ParserFactory.CreateParser(suppliername);

			string rawData = await parser.FetchRawData(url);

			IHotelAdapter adapter =  AdapterFactory.CreateAdapter(suppliername);

			return await adapter.ConvertToHotel(rawData);
		}
	}
}
