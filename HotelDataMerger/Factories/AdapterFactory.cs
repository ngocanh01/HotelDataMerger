using HotelDataMerger.Adapters;

namespace HotelDataMerger.Factories
{
	public static class AdapterFactory
	{
		public static IHotelAdapter CreateAdapter(string supplierName)
		{
			return supplierName switch
			{
				"Acme" => new AcmeAdapter(),
				"Patagonia" => new PatagoniaAdapter(),
				"Paperflies" => new PaperfliesAdapter(),
				_ => throw new ArgumentException("Invalid supplier name")
			};
		}
	}
}
