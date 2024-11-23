using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using System.Text.Json;

namespace HotelDataMerger.Adapters
{
    public class PatagoniaAdapter : IHotelAdapter
	{
		public async Task<List<Hotel>> ConvertToHotel(string rawData)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
			};

			List<PatagoniaSupplier> hotels = JsonSerializer.Deserialize<List<PatagoniaSupplier>>(rawData, options);

			return PatagoniaMapper.MapToHotelResponseList(hotels);
		}
	}
}
