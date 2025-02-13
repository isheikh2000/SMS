namespace SuperMarket.Domain.Interfaces
{
    public interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }
}
