using StrategyPatternExample.Strategies;

namespace StrategyPatternExample;

/// <summary>
/// Proxy for routing to the correct strategy
/// </summary>
public interface IFormattingProxy
{
    /// <summary>
    /// Note that this method is almost identical to <see cref="IFormattingStrategy.SerializeResults"/>,
    /// except it takes an <see cref="OutputFormat"/> enum to tell it which format to use.
    /// </summary>
    Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts, OutputFormat outputFormat);
}

/// <inheritdoc />
public class FormattingProxy : IFormattingProxy
{
    private readonly IEnumerable<IFormattingStrategy> _formattingStrategies;

    /// <summary>
    /// Note that we take an <see cref="IEnumerable{T}"/> of strategies from
    /// the service collection. This will contain a single instance of each service
    /// in the collection which implements the <see cref="IFormattingStrategy"/> interface.
    /// </summary>
    public FormattingProxy(IEnumerable<IFormattingStrategy> formattingStrategies)
    {
        _formattingStrategies = formattingStrategies;
    }

    /// <inheritdoc />
    public Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts, OutputFormat outputFormat)
    {
        // First, we select the correct strategy based on the enum value
        var formattingStrategy = _formattingStrategies
            .FirstOrDefault(x => x.OutputFormat == outputFormat);

        // It is usually best to guard for unmatched strategies.
        // Here we will just throw an exception for brevity of the example.
        if (formattingStrategy is null)
            throw new NotSupportedException($"Output format {outputFormat} is not supported");

        // Finally, invoke the strategy to serialize to the correct format
        return formattingStrategy.SerializeResults(weatherForecasts);
    }
}