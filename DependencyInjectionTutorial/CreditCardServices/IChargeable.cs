namespace DependencyInjectionTutorial.CreditCardServices
{
    public interface IChargeable
    {
        public void Charge(decimal amount);
    }
}