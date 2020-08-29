using System;
using System.Dynamic;

namespace DependencyInjectionTutorial
{
    public enum EnvironmentType
    {
        Production,
        Staging,
        Development
    }
    
    public static class AppConfiguration
    {
        public static EnvironmentType EnvType { get; private set; }
        
        static AppConfiguration() {
            EnvType = SetEnvironmentType();
            // MessageOfTheDay = "Seven days without a pun makes one week.";
        }

        private static EnvironmentType SetEnvironmentType()
        {
            var envVariable = Environment.GetEnvironmentVariable("env")?.ToLower();

            var envType = envVariable switch
            {
                "prod" => EnvironmentType.Production,
                "production" => EnvironmentType.Production,
                "stage" => EnvironmentType.Staging,
                "staging" => EnvironmentType.Staging,
                "dev" => EnvironmentType.Development,
                "development" => EnvironmentType.Development,
                _ => EnvironmentType.Development
            };

            return envType;
        }
    }
}