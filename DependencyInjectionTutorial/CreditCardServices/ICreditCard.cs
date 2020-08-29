namespace DependencyInjectionTutorial.CreditCardServices
{
    public interface ICreditCard : IChargeable, ILoadable
    {
        public decimal Balance { get; }
    }
}