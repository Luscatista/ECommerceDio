namespace ECommerceDio.Exceptions;

public class InsufficientStockException : Exception
{
    public InsufficientStockException(string productName) : base($"Product {productName} has insufficient ")
    {
        
    }
}