namespace HotelDataMerger.Parsers
{
	public class DataParser : IDataParser
	{
		private readonly HttpClient _httpClient;

		public DataParser()
		{
			_httpClient = new HttpClient();
		}
		public async Task<string> FetchRawDataAsync(string url)
		{
            var response = await _httpClient.GetAsync(url);
			response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            if (response.StatusCode != System.Net.HttpStatusCode.OK)			
				return string.Empty;			

            return await response.Content.ReadAsStringAsync();        
		}
	}
}
