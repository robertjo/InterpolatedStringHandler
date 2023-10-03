using InterpolatedStringHandler.Classes;

namespace InterpolatedStringHandler;

internal static class Program
{
    private static void Main()
    {
        ConsoleEx.WriteLine("Console Start!");
        ConsoleEx.WriteDashedLine();
        ConsoleEx.WriteLine("Using Logger1 and LogInterpolatedStringHandler1");
        ConsoleEx.WriteDashedLine();

        var logger1 = new Logger1() { EnabledLevel = LogLevel.Warning };
        var time = DateTime.Now;

        logger1.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. The time doesn't use formatting.");
        logger1.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time:t}. This is an error. It will be printed.");
        logger1.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time:t}. This won't be printed.");
        logger1.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");

        ConsoleEx.WriteDashedLine();
        ConsoleEx.WriteLine("Using Logger2 and LogInterpolatedStringHandler2");
        ConsoleEx.WriteDashedLine();

        var logger2 = new Logger2() { EnabledLevel = LogLevel.Warning };
        int index = 0;
        int numberOfIncrements = 0;
        for (var level = LogLevel.Critical; level <= LogLevel.Trace; level++)
        {
            Console.WriteLine(level);
            logger2.LogMessage(level, $"{level}: Increment index a few times {index++}, {index++}, {index++}, {index++}, {index++}");
            numberOfIncrements += 5;
        }

        Console.WriteLine($"Value of index {index}, value of numberOfIncrements: {numberOfIncrements}");

        ConsoleEx.WriteDashedLine();
        ConsoleEx.WriteLine("Console End!");
    }
}