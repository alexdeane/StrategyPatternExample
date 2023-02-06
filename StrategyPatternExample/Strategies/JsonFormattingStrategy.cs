using System.Text.Json;

namespace StrategyPatternExample.Strategies;

/// <summary>
/// This implementation of the <see cref="IFormattingStrategy"/> formats
/// the results to JSON. As such, it implements the public member <see cref="OutputFormat"/>
/// to return <see cref="StrategyPatternExample.OutputFormat.Json"/>.
/// </summary>
public class JsonFormattingStrategy : IFormattingStrategy
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    /// <summary>
    /// <inheritdoc />
    /// <br/>
    /// This formatter supports <see cref="StrategyPatternExample.OutputFormat.Json"/>
    /// </summary>
    public OutputFormat OutputFormat => OutputFormat.Json;

    /// <inheritdoc />
    public async Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts)
    {
        await using var stream = new MemoryStream();

        await JsonSerializer.SerializeAsync(stream, weatherForecasts, JsonSerializerOptions);

        stream.Position = 0;

        using var streamReader = new StreamReader(stream);

        return await streamReader.ReadToEndAsync();
    }
}