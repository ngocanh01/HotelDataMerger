using HotelDataMerger.Models;
using HotelDataMerger.Parsers;
using System.Text.Json;

namespace HotelDataMerger.Adapters;

public abstract class BaseAdapter<TSupplier> : IHotelAdapter
	where TSupplier : BaseSupplier
{
	private readonly DataParser _dataParser;
	private readonly JsonSerializerOptions _jsonOptions;

	protected BaseAdapter(DataParser dataParser)
	{
		_dataParser = dataParser;
		_jsonOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
		};
	}

	protected abstract string SupplierUrl { get; }
	public abstract ApiName ApiName { get; }

	protected abstract List<Hotel> MapToHotelResponseList(List<TSupplier> suppliers);

	public async Task<List<Hotel>> ConvertToHotelAsync()
	{
		string rawData = await _dataParser.FetchRawDataAsync(SupplierUrl);
		if (string.IsNullOrEmpty(rawData))		
			return new List<Hotel>();		

		List<TSupplier> supplierData = JsonSerializer.Deserialize<List<TSupplier>>(rawData, _jsonOptions) ?? new List<TSupplier>();
		return MapToHotelResponseList(supplierData);
	}
}


