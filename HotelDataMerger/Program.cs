using HotelDataMerger.Adapters;
using HotelDataMerger.Factories;
using HotelDataMerger.Parsers;
using HotelDataMerger.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

public class Program
{
	// Main method
	public static async Task Main(string[] args)
	{
		var host = Host.CreateDefaultBuilder(args)
			.ConfigureServices((_, services) =>
			{
				// Register services here
				services.AddSingleton<DataParser>();
				services.AddSingleton<HotelAdapterFactory>();
				services.AddScoped<IHotelAdapter, AcmeAdapter>();
				services.AddScoped<IHotelAdapter, PatagoniaAdapter>();
				services.AddScoped<IHotelAdapter, PaperfliesAdapter>();
				services.AddTransient<IHotelService, HotelService>();
			})
			.Build();

		var hotelService = host.Services.GetRequiredService<IHotelService>();

		// Resolve Program service and run the application
		if (args.Length < 2)
		{
			Console.WriteLine("Usage: runner.bat <hotel_ids> <destination_ids>");
			return;
		}

		// Parse arguments, handling "none" case for optional filtering
		var hotelIds = args[0].Equals("none", StringComparison.OrdinalIgnoreCase)
			? null
			: args[0].Split(',').ToList();

		var destinationIds = args[1].Equals("none", StringComparison.OrdinalIgnoreCase)
			? null
			: args[1].Split(',').Select(int.Parse).ToList();

		// Get hotels and apply filters
		var hotelInfos = await hotelService.GetHotelDataAsync();
		var filteredHotels = hotelService.FilterHotels(hotelInfos, hotelIds, destinationIds);

		// Serialize to JSON with indentation
		var options = new JsonSerializerOptions { WriteIndented = true };
		string jsonResult = JsonSerializer.Serialize(filteredHotels, options);

		Console.WriteLine(jsonResult);
	}
}
