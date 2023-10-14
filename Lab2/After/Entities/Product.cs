using After.Common;

namespace After.Entities
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; } = null!;
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public static Result<Product> Create(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Product>.Failure("Name is required");
            }
            if (price <= 0)
            {
                return Result<Product>.Failure("Price must be greater than 0");
            }
            return Result<Product>.Success(new Product
            {
                ProductId = Guid.NewGuid(),
                Name = name,
                Price = price,
            });
        }

        public void DisplayProductInformation()
        {
            Console.WriteLine($"The price of {Name} is {Price}");
        }

        public Result<Product> IncreasePriceBy(decimal price)
        {
            if (price <= 0)
            {
               return Result<Product>.Failure("Price must be greater than 0");
            }
            Price += price;
            return Result<Product>.Success(this);
        }

        public Result<Product> DecreasePriceBy(decimal price)
        {
            if (price <= 0)
            {
                return Result<Product>.Failure("Price must be greater than 0");
            }
            if (Price < price)
            {
                return Result<Product>.Failure("The price to decrease is greater than the current price");
            }
            Price -= price;
            return Result<Product>.Success(this);
        }
    }
}
    