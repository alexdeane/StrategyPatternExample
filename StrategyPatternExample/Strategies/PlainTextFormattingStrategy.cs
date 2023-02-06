using System.Globalization;
using System.Text;

namespace StrategyPatternExample.Strategies;

/// <summary>
/// This implementation of the <see cref="IFormattingStrategy"/> formats
/// the results to Plain text. As such, it implements the public member <see cref="OutputFormat"/>
/// to return <see cref="StrategyPatternExample.OutputFormat.PlainText"/>.
/// </summary>
public class PlainTextFormattingStrategy : IFormattingStrategy
{
    /// <summary>
    /// <inheritdoc />
    /// <br/>
    /// This formatter supports <see cref="StrategyPatternExample.OutputFormat.PlainText"/>
    /// </summary>
    public OutputFormat OutputFormat => OutputFormat.PlainText;

    /// <inheritdoc />
    public Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts)
    {
        var stringBuilder = new StringBuilder();

        foreach (var weatherForecast in weatherForecasts)
        {
            var dateString = weatherForecast.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            stringBuilder.AppendLine($"Forecast for {dateString}:");
            stringBuilder.AppendLine($"\tTemperature: {weatherForecast.Temperature}°F");
            stringBuilder.AppendLine($"\tSummary: {weatherForecast.Summary}");
            stringBuilder.AppendLine();
        }

        return Task.FromResult(stringBuilder.ToString());
    }
}