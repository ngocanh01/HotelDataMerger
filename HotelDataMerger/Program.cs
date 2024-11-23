using HotelDataMerger;
using HotelDataMerger.Models;
using HotelDataMerger.Services;
using System.Text.Json;

public class Program
{
	public static async Task Main(string[] args)
	{
		if (args.Length < 2)
		{
			Console.WriteLine("Usage: runner.bat <hotel_ids> <destination_ids>");
			return;
		}
		var hotelIds = args[0] == "none" ? null : args[0].Split(',').ToList();
		var destinationIds = args[1] == "none" ? null : args[1].Split(',').Select(int.Parse).ToList();

		const string ACEME_URL = "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/acme";
		const string PATAGONIA_URL = "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/patagonia";
		const string PAPERFLIES_URL = "https://5f2be0b4ffc88500167b85a0.mockapi.io/suppliers/paperflies";

		const string ACEME = "Acme";
		const string PATAGONIA = "Patagonia";
		const string PAPERFLIES = "Paperflies";

		HotelService hotelService = new();
		DataMerger dataMerger = new();
		HotelFilter hotelFilter = new();

		List<Hotel> acemeData = await hotelService.GetHotelData(ACEME_URL, ACEME);
		List<Hotel> patagoniaData = await hotelService.GetHotelData(PATAGONIA_URL, PATAGONIA);
		List<Hotel> paperfliesData = await hotelService.GetHotelData(PAPERFLIES_URL, PAPERFLIES);

		// merge data
		var mergedHotels = dataMerger.MergeHotelListsWithFullData(acemeData, patagoniaData, paperfliesData);
		// filter data
		var filteredHotels = hotelFilter.FilterHotels(mergedHotels, hotelIds, destinationIds);

		var options = new JsonSerializerOptions { WriteIndented = true };
		string jsonResult = JsonSerializer.Serialize(filteredHotels, options);
		Console.WriteLine(jsonResult);
	}
}