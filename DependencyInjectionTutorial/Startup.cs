using System;
using Autofac;
using DependencyInjectionTutorial.CreditCardServices;

namespace DependencyInjectionTutorial
{
    public class Startup
    {
        private readonly CreditCardService _cardService;

        public Startup(CreditCardService cardService)
        {
            _cardService = cardService;
        }
        
        public void Run()
        {
            var shouldContinue = -1;
            
            do
            {
                RunIntro();
                shouldContinue = RunSelection();
            } while (shouldContinue == -1);
        }

        public void RunIntro()
        {
            Console.WriteLine("Welcome to the card reader 9000!"); 
            Console.WriteLine("In the card reader 9000 you will be able to charge your card and update your account balance!");
        }

        private int RunSelection()
        {
            Console.WriteLine("Please choose your action: ");
            Console.WriteLine("    (1) Load Card");
            Console.WriteLine("    (2) Charge Card");
            //Console.WriteLine("    (3) Back To Card Selection");
            Console.WriteLine("    (q) Exit");
            Console.Write("Selection: ");
            var keyPress = Console.ReadKey();
            Console.WriteLine();

            switch (keyPress.Key)
            {
                case ConsoleKey.D1:
                    _cardService.RequestCardNumber();
                    _cardService.LoadCard();
                    _cardService.DisplayBalance();
                    break;
                case ConsoleKey.D2:
                    _cardService.RequestCardNumber();
                    _cardService.ChargeCard();
                    _cardService.DisplayBalance();
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }

            Console.ReadLine();
            Console.Clear();
            return -1;
        }
    }
}