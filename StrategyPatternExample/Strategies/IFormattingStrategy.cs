namespace StrategyPatternExample.Strategies;

/// <summary>
/// This interface backs all of the strategies for formatting output.
/// We can add as many as we want here without having to change much
/// code anywhere else.
/// </summary>
public interface IFormattingStrategy
{
    /// <summary>
    /// The <see cref="OutputFormat"/> which this strategy supports. This
    /// is used to inform the proxy as to which strategy to select.
    /// </summary>
    OutputFormat OutputFormat { get; }

    /// <summary>
    /// Serializes the <see cref="WeatherForecast"/>s to a string of a certain format 
    /// </summary>
    Task<string> SerializeResults(IEnumerable<WeatherForecast> weatherForecasts);
}