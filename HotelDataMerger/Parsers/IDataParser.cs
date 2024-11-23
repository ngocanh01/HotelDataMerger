namespace HotelDataMerger.Parsers
{
	public interface IDataParser
	{
		Task<string> FetchRawData(string url);
	}
}
