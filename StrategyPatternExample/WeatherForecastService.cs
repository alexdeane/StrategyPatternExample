namespace StrategyPatternExample;

/// <summary>
/// Basic service to generate DTO data. In reality this would probably
/// be backed by a database, and would include a mapping from entity to DTO
/// </summary>
public interface IWeatherForecastService
{
    /// <returns><see cref="IEnumerable{T}"/> of <see cref="WeatherForecast"/> data</returns>
    public IEnumerable<WeatherForecast> GetForecasts();
}

public class WeatherForecastService : IWeatherForecastService
{
    /// <summary>
    /// For brevity and the purposes of example,
    /// this just returns hardcoded data. 
    /// </summary>
    public IEnumerable<WeatherForecast> GetForecasts()
    {
        return new WeatherForecast[]
        {
            new()
            {
                Temperature = 32,
                Date = new DateTime(
                    year: 2023,
                    month: 2,
                    day: 5
                ),
                Summary = "Partly cloudy"
            },
            new()
            {
                Temperature = 0,
                Date = new DateTime(
                    year: 2023,
                    month: 2,
                    day: 4
                ),
                Summary = "Sunny"
            }
        };
    }
}

/// <summary>
/// Basic DTO for a weather forecast
/// </summary>
public class WeatherForecast
{
    public int Temperature { get; init; }
    public DateTime Date { get; init; }
    public string? Summary { get; init; }
}