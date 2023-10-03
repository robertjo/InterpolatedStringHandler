using InterpolatedStringHandler.StringHandlers;
using System.Runtime.CompilerServices;

namespace InterpolatedStringHandler.Classes;

internal class Logger1
{
    public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

    public void LogMessage(LogLevel level, string msg)
    {
        if (EnabledLevel < level) return;
        Console.WriteLine(msg);
    }

    public void LogMessage(
        LogLevel level,
        [InterpolatedStringHandlerArgument("", "level")] LogInterpolatedStringHandler1 builder)
    {
        if (EnabledLevel < level) return;
        Console.WriteLine(builder.GetFormattedText());
    }
}