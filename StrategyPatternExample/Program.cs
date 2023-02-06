using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using StrategyPatternExample;
using StrategyPatternExample.Strategies;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<AppController>();
serviceCollection.AddSingleton<IWeatherForecastService, WeatherForecastService>();

// In this example, we inject multiple implementations of the same interface
serviceCollection.AddSingleton<IFormattingStrategy, JsonFormattingStrategy>();
serviceCollection.AddSingleton<IFormattingStrategy, XmlFormattingStrategyService>();
serviceCollection.AddSingleton<IFormattingStrategy, PlainTextFormattingStrategy>();

// Inject the proxy service
serviceCollection.AddSingleton<IFormattingProxy, FormattingProxy>();

// Inject the CLI arguments
serviceCollection.AddSingleton(new LaunchArguments(Environment.GetCommandLineArgs()));

var serviceProvider = serviceCollection.BuildServiceProvider();
var controller = serviceProvider.GetRequiredService<AppController>();

// Run the app
await controller.Run();