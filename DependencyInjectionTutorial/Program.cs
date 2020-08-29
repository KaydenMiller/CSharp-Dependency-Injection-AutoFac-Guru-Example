using System;
using System.Runtime.CompilerServices;
using Autofac;
using DependencyInjectionTutorial.CreditCardServices;

namespace DependencyInjectionTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot().Resolve<Startup>().Run();
        }

        static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            switch (AppConfiguration.EnvType)
            {
                case EnvironmentType.Production:
                    builder.RegisterType<PriorityLogger>().As<ILogger>();
                    break;
                case EnvironmentType.Staging:
                    builder.RegisterType<PriorityLogger>().As<ILogger>();
                    break;
                default:
                case EnvironmentType.Development:
                    builder.RegisterType<DateTimeLogger>().As<ILogger>();
                    break;
            }

            builder.RegisterType<CreditCardService>();

            builder.Register<ICreditCard>((c, p) =>
            {
                var cardNumber = p.Named<string>("cardNumber");
                if (cardNumber.StartsWith("9")) return new PremiumCard();
                if (cardNumber.StartsWith("7")) return new GoldCard();
                return new StandardCard();
            });

            builder.RegisterType<Startup>();

            return builder.Build();
        }
    }
}