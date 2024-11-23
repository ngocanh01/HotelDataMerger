using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using System.Text.Json;

namespace HotelDataMerger.Adapters
{
    public class AcmeAdapter : IHotelAdapter
	{
		public async Task<List<Hotel>> ConvertToHotel(string rawData)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
			};

			List<AcmeSupplier> hotels = JsonSerializer.Deserialize<List<AcmeSupplier>>(rawData, options);

			return AcmeMapper.MapToHotelResponseList(hotels);
		}
	}
}
