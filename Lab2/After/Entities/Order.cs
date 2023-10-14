using After.Common;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Entities
{
    public class Order
    {
        public Guid OrderId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Customer Customer { get; private set; } = null!;

        private Order()
        {
        }

        public static Result<Order> Create(DateTime orderDate, decimal totalAmount, Customer customer)
        {
            if (orderDate == default)
            {
                return Result<Order>.Failure("Order date is required");
            }
            if (totalAmount <= 0)
            {
                return Result<Order>.Failure("Total amount must be greater than 0");
            }
            if (customer == null)
            {
                return Result<Order>.Failure("Customer is required");
            }
            //Guard.Against.NegativeOrZero(totalAmount, nameof(totalAmount));
            //Guard.Against.Null(customer, nameof(customer));
            //Guard.Against.Default(orderDate, nameof(orderDate));
            return Result<Order>.Success(new Order
            {
                OrderId = Guid.NewGuid(),
                OrderDate = orderDate,
                TotalAmount = totalAmount,
                Customer = customer
            });
        }

        public decimal CalculateDiscount()
        {
            if (TotalAmount > 1000)
            {
                return TotalAmount * 0.05m;
            }
            else
            {
                return 0;
            }
        }
    }
}
