using System.Xml.Serialization;

namespace StrategyPatternExample.Strategies;

/// <summary>
/// This implementation of the <see cref="IFormattingStrategy"/> formats
/// the results to XML. As such, it implements the public member <see cref="OutputFormat"/>
/// to return <see cref="OutputFormat.Xml"/>.
/// </summary>
public class XmlFormattingStrategyService : IFormattingStrategy
{
    /// <summary>
    /// <inheritdoc />
    /// <br/>
    /// This formatter supports <see cref="StrategyPatternExample.OutputFormat.Xml"/>
    /// </summary>
    public OutputFormat OutputFormat => OutputFormat.Xml;

    /// <inheritdoc />
    public async Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts)
    {
        var xmlSerializer = new XmlSerializer(typeof(WeatherForecast[]));

        await using var stream = new MemoryStream();

        xmlSerializer.Serialize(stream, weatherForecasts.ToArray());

        stream.Position = 0;

        using var streamReader = new StreamReader(stream);

        return await streamReader.ReadToEndAsync();
    }
}