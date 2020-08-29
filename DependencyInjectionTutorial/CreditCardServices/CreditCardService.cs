using System;
using Autofac;

namespace DependencyInjectionTutorial.CreditCardServices
{
    public class CreditCardService
    {
        private ILogger _logger;
        private ILifetimeScope _scope;
        private ICreditCard currentCard;
        public string CardNumber { get; private set; }

        public CreditCardService(ILogger logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public void RequestCardNumber()
        {
            var cardValid = -1;
            do
            {
                Console.Write("Please enter your card number now: ");
                cardValid = ParseCardNumber(Console.ReadLine());
                currentCard = _scope.Resolve<ICreditCard>(new NamedParameter("cardNumber", CardNumber));
                DisplayBalance();
            } while (cardValid == -1);
        }

        public void LoadCard()
        {
            Console.WriteLine($"The card {CardNumber} is a {currentCard.GetType().FullName} Card!");
            currentCard.Load(10);
        }

        public void ChargeCard()
        {
            Console.WriteLine($"The card {CardNumber} is a {currentCard.GetType().FullName} Card!");
            currentCard.Charge(10);
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"The card balance for {CardNumber} is: {currentCard.Balance:C}");
            if (currentCard.GetType() == typeof(PremiumCard))
            {
                var c = (currentCard as PremiumCard);
                Console.WriteLine("The rewards balance on your card is: {0} points", c?.Rewards);
            }
            else if (currentCard.GetType() == typeof(GoldCard))
            {
                var c = (currentCard as GoldCard);
                Console.WriteLine("The rewards balance on your card is: {0} points", c?.Rewards);
            }
        }

        private int ParseCardNumber(string cardInput)
        {
            if (String.IsNullOrWhiteSpace(cardInput) || String.IsNullOrEmpty(cardInput))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid card number!");
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            
            CardNumber = cardInput;
            _logger.Log($"{CardNumber} was selected as the card to use.");

            return 1;
        }
    }
}