namespace InterpolatedStringHandler.Classes;

internal static class ConsoleEx
{
    private const int DashedLineMaxLength = 75;
    private const ConsoleColor SelectedColor = ConsoleColor.Green;

    public static void WriteDashedLine()
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = SelectedColor;
        Console.WriteLine(new string('-', DashedLineMaxLength));
        Console.ForegroundColor = oldColor;
    }

    public static void WriteLine(string message)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = SelectedColor;
        Console.WriteLine(message);
        Console.ForegroundColor = oldColor;
    }
}