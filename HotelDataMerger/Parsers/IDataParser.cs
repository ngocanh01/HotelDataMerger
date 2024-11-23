namespace HotelDataMerger.Parsers
{
	public interface IDataParser
	{
		Task<string> FetchRawDataAsync(string url);
	}
}
