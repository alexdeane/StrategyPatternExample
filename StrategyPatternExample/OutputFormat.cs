namespace StrategyPatternExample;

/// <summary>
/// Enumeration defining the different
/// output formats supported by the application.
///
/// This is used by the proxy to route to the correct strategy.
/// </summary>
public enum OutputFormat
{
    Json,
    Xml,
    PlainText
}