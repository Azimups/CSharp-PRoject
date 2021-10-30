using System;
namespace CsharpProject.Helper
{
    static class Extensions
    {
        static public void Print(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
