namespace SuperMarket.Domain.Interfaces
{
    public interface IPricingStrategy
    {
        int GetPrice(int Quantity);
    }
}
