using After.Common;

namespace After.Entities
{
    public class InventoryItem
    {
        public Guid InventoryItemId { get; private set; }
        public Product Product { get; private set; } = null!;
        public int Quantity { get; private set; }

        private InventoryItem()
        {
        }

        public static Result<InventoryItem> Create(Product product, int quantity)
        {
            if (product == null)
            {
                return Result<InventoryItem>.Failure("A product is required");
            }
            if (quantity <= 0)
            {
                return Result<InventoryItem>.Failure("The quantity must be greater than 0");
            }
            return Result<InventoryItem>.Success(new InventoryItem
            {
                InventoryItemId = Guid.NewGuid(),
                Product = product,
                Quantity = quantity,
            });
        }

        public Result<InventoryItem> AddQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                return Result<InventoryItem>.Failure("The quantity must be greater than 0");
            }
            Quantity += quantity;
            return Result<InventoryItem>.Success(this);
        }

        public Result<InventoryItem> RemoveQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                return Result<InventoryItem>.Failure("The quantity must be greater than 0");
            }
            if (Quantity < quantity)
            {
                return Result<InventoryItem>.Failure("The quantity to remove is greater than the current quantity");
            }
            Quantity -= quantity;
            return Result<InventoryItem>.Success(this);
        }

        public void DisplayQuantity()
        {
            Console.WriteLine($"The quantity of {Product.Name} is {Quantity}");
        }
    }
}
