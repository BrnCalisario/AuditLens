namespace ExampleApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; } = decimal.Zero;
        public OrderType OrderType { get; set; }
    }

    public enum OrderType
    {
        Purchase,
        Sale,
    }
}