namespace HotelDataMerger.Parsers
{
	public class DataParser : IDataParser
	{
		private readonly HttpClient _httpClient;

		public DataParser()
		{
			_httpClient = new HttpClient();
		}
		public async Task<string> FetchRawData(string url)
		{
			var response = await _httpClient.GetAsync(url);
			response.EnsureSuccessStatusCode(); 

			return await response.Content.ReadAsStringAsync();
		}
	}
}
