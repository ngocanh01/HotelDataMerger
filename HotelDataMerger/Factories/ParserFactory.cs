using HotelDataMerger.Parsers;

namespace HotelDataMerger.Factories
{
	public static class ParserFactory
	{
		public static IDataParser CreateParser(string supplierName)
		{
			return supplierName switch
			{
				"Acme" => new DataParser(),
				"Patagonia" => new DataParser(),
				"Paperflies" => new DataParser(),
				_ => throw new ArgumentException("Invalid supplier name")
			};
		}
	}
}
