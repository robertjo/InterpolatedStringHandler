using InterpolatedStringHandler.Classes;
using System.Runtime.CompilerServices;
using System.Text;

namespace InterpolatedStringHandler.StringHandlers;

[InterpolatedStringHandler]
internal readonly struct LogInterpolatedStringHandler2
{
    // Storage for the built-up string
    private readonly StringBuilder builder;

    public LogInterpolatedStringHandler2(
        int literalLength,
        int formattedCount,
        Logger2 logger,
        LogLevel level,
        out bool isEnabled)
    {
        isEnabled = logger.EnabledLevel >= level;
        builder = isEnabled ? new StringBuilder(literalLength) : default!;
    }

    public readonly void AppendLiteral(string s)
    {
        builder.Append(s);
    }

    public readonly void AppendFormatted<T>(T t)
    {
        builder.Append(t?.ToString());
    }

    public readonly void AppendFormatted<T>(T t, string format) where T : IFormattable
    {
        builder.Append(t?.ToString(format, null));
    }

    internal readonly string GetFormattedText() => builder.ToString();
}