using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using HotelDataMerger.Parsers;

namespace HotelDataMerger.Adapters
{
	public class PatagoniaAdapter(DataParser dataParser) : BaseAdapter<PatagoniaSupplier>(dataParser)
	{
		// Unique URL for Patagonia data
		protected override string SupplierUrl => "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/patagonia";
		public override ApiName ApiName => ApiName.Patagonia;

		// Mapping function from PatagoniaSupplier to Hotel
		protected override List<Hotel> MapToHotelResponseList(List<PatagoniaSupplier> suppliers)
		{
			return PatagoniaMapper.MapToHotelResponseList(suppliers);
		}
	}
}
