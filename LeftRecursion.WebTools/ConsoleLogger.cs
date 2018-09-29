using System;

namespace LeftRecursion.WebTools
{
    internal class ConsoleLogger : IHttpClientLogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}