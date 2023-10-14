using After.Common;

namespace After.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;

        private Customer()
        {
        }

        public static Result<Customer> Create(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return Result<Customer>.Failure("First name is required");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                return Result<Customer>.Failure("Last name is required");
            }

            return Result<Customer>.Success(new Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName
            });
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
    