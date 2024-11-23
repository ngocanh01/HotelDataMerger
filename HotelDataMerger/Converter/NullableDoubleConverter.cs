using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelDataMerger.Converter
{
	public class NullableDoubleConverter : JsonConverter<double?>
	{
		public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				var value = reader.GetString();
				return string.IsNullOrEmpty(value) ? (double?)null : Convert.ToDouble(value);
			}
			return reader.TokenType == JsonTokenType.Number ? reader.GetDouble() : (double?)null;
		}

		public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
		{
			writer.WriteNumberValue(value ?? 0.0); // Write 0.0 if value is null
		}
	}
}
