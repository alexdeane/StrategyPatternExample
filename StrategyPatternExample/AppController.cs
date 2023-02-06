namespace StrategyPatternExample;

/// <summary>
/// You can pretend that this is an API controller or something
/// </summary>
public class AppController
{
    private readonly IWeatherForecastService _service;
    private readonly IFormattingProxy _formattingProxy;
    private readonly LaunchArguments _launchArguments;

    /// <summary>
    /// The class accepts its dependencies in the constructor. You would
    /// say that the class has its dependencies "injected" at runtime,
    /// rather than having to instantiate them itself.
    ///
    /// This allows the code of this class to be VERY decoupled from the rest of the code,
    /// making unit testing much easier and making the code quite a bit more modular. 
    /// </summary>
    public AppController(
        IWeatherForecastService service,
        IFormattingProxy formattingProxy,
        LaunchArguments launchArguments
    )
    {
        _service = service;
        _formattingProxy = formattingProxy;
        _launchArguments = launchArguments;
    }

    /// <summary>
    /// Runs the program. Imagine this is a controller action.
    /// </summary>
    public Task Run()
    {
        var weatherForecasts = _service.GetForecasts();

        if (!TryParseFormat(out var format))
        {
            Console.WriteLine("Invalid format");
            return Task.CompletedTask;
        }

        return _formattingProxy.SerializeResults(weatherForecasts, format)
            .ContinueWith(x => { Console.WriteLine(x.Result); });
    }

    private bool TryParseFormat(out OutputFormat outputFormat)
    {
        var firstArg = _launchArguments.Arguments.ElementAtOrDefault(1);

        return Enum.TryParse(
            value: firstArg,
            ignoreCase: true,
            result: out outputFormat
        );
    }
}

/// <summary>
/// Simple record to encapsulate DI. Only exists because directly
/// dependency injecting "string[]" is cringe and could lead
/// to conflicts if multiple classes have different dependencies of that
/// common type.
///
/// In reality we would wrap in an IOptions{} or something
/// </summary>
public record LaunchArguments(string[] Arguments);