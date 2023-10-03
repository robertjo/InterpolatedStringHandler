using InterpolatedStringHandler.Classes;
using System.Runtime.CompilerServices;
using System.Text;

namespace InterpolatedStringHandler.StringHandlers;

[InterpolatedStringHandler]
internal readonly struct LogInterpolatedStringHandler1
{
    // Storage for the built-up string
    private readonly StringBuilder builder;

    public LogInterpolatedStringHandler1(
        int literalLength,
        int formattedCount,
        Logger1 logger,
        LogLevel level,
        out bool isEnabled)
    {
        isEnabled = logger.EnabledLevel >= level;
        Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        builder = isEnabled ? new StringBuilder(literalLength) : default!;
    }

    public void AppendLiteral(string s)
    {
        Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
        builder.Append(s);
        Console.WriteLine($"\tAppended the literal string");
    }

    public void AppendFormatted<T>(T t)
    {
        Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
        builder.Append(t?.ToString());
        Console.WriteLine($"\tAppended the formatted object");
    }

    public void AppendFormatted<T>(T t, string format) where T : IFormattable
    {
        Console.WriteLine($"\tAppendFormatted (IFormattable version) called: {t} with format {{{format}}} is of type {typeof(T)},");
        builder.Append(t?.ToString(format, null));
        Console.WriteLine($"\tAppended the formatted object");
    }

    internal readonly string GetFormattedText() => builder.ToString();
}