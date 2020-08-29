using System;
using System.Globalization;

namespace DependencyInjectionTutorial
{
    public class DateTimeLogger : ILogger
    {
        public void Log(string output)
        {
            Console.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + ": " + output);
        }
    }
}