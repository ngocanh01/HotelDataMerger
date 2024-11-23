using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using System.Text.Json;

namespace HotelDataMerger.Adapters
{
    public class PaperfliesAdapter : IHotelAdapter
	{
		public async Task<List<Hotel>> ConvertToHotel(string rawData)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
			};

			List<PaperfliesSupplier> hotels = JsonSerializer.Deserialize<List<PaperfliesSupplier>>(rawData, options);

			return PaperfliesMapper.MapToHotelResponseList(hotels);
		}
	}
}
