using HotelDataMerger.Mappers;
using HotelDataMerger.Models;
using HotelDataMerger.Parsers;

namespace HotelDataMerger.Adapters
{

	public class PaperfliesAdapter(DataParser dataParser) : BaseAdapter<PaperfliesSupplier>(dataParser)
	{
		// Unique URL for Paperflies data
		protected override string SupplierUrl => "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/paperflies";
		public override ApiName ApiName => ApiName.Paperflies;

		// Mapping function from PaperfliesSupplier to Hotel
		protected override List<Hotel> MapToHotelResponseList(List<PaperfliesSupplier> suppliers)
		{
			return PaperfliesMapper.MapToHotelResponseList(suppliers);
		}
	}
}
