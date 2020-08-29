using System;

namespace DependencyInjectionTutorial
{
    public class PriorityLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"High: {message}");
        }
    }
}