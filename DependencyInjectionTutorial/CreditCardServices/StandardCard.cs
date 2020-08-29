using System;

namespace DependencyInjectionTutorial.CreditCardServices
{
    public class StandardCard : ICreditCard
    {
        public decimal Balance { get; private set; }
        
        public StandardCard()
        {
            var rand = new Random();
            Balance = rand.Next(-100, 100);
        }

        public void Charge(decimal amount)
        {
            Balance -= amount;
        }

        public void Load(decimal amount)
        {
            Balance += amount;
        }
    }
}