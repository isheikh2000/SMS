namespace SuperMarket.Domain.Exceptions
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException(string item)
            : base ($"Invalid Product: {item}")
        {
            
        }
    }
}
