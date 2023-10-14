namespace Before
{
    public class OrderService
    {
        public decimal CalculateDiscount(Order order)
        {
            if(order.TotalAmount > 1000)
            {
                return order.TotalAmount * 0.05m;
            }
            else
            {
                return 0;
            }
        }

        public string GetFullName(Customer customer)
        {
            return $"{customer.FirstName} {customer.LastName}";
        }
    }
}
