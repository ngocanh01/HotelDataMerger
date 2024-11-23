using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using HotelDataMerger.Parsers;

namespace HotelDataMerger.Adapters
{
	public class AcmeAdapter(DataParser dataParser) : BaseAdapter<AcmeSupplier>(dataParser)
	{
		// Unique URL for Acme data
		protected override string SupplierUrl => "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/acme";
		public override ApiName ApiName => ApiName.Aceme;

		// Mapping function from AcmeSupplier to Hotel
		protected override List<Hotel> MapToHotelResponseList(List<AcmeSupplier> suppliers)
		{
			return AcmeMapper.MapToHotelResponseList(suppliers);
		}
	}
}