using HotelDataMerger.Adapters;

namespace HotelDataMerger.Factories
{
	public class HotelAdapterFactory
	{
		private readonly IDictionary<ApiName, IHotelAdapter> _adapters;

		public HotelAdapterFactory(IEnumerable<IHotelAdapter> adapters)
		{
			_adapters = adapters.ToDictionary(adapter => adapter.ApiName);
		}

		public IHotelAdapter? CreateAdapter(ApiName supplierName)
		{
			if(_adapters.TryGetValue(supplierName, out var adapter))
			{
				return adapter;
			}

			return null;
		}
	}
}
