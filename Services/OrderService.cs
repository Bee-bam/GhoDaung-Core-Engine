using Microsoft.EntityFrameworkCore;
using Gho_Daung___Order___Inventory_System__.Models;
using Gho_Daung___Order___Inventory_System__.Data;
using Gho_Daung___Order___Inventory_System__.Enums;

namespace Gho_Daung___Order___Inventory_System__.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OrderResult> PlaceOrderAsync(int ProductId,int requestedQuantity)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var ProductInInventory = await _context.Inventories.Include(i => i.Product).FirstOrDefaultAsync(i => i.Product_Id == ProductId);

                if (ProductInInventory == null) 
                {
                    return OrderResult.ProductNotFound;
                }

                if (requestedQuantity > ProductInInventory.Quantity)
                {
                    return OrderResult.OutofStock;
                }
                ProductInInventory.Quantity -= requestedQuantity;

                var newOrder = new Order
                {
                    Order_Date = DateTime.Now,
                    Total_Amount = ProductInInventory.Product.Price * requestedQuantity
                };
                _context.Orders.Add(newOrder);

                var newOrderItem = new OrderItem
                {
                    Order = newOrder,
                    Product_Id = ProductId,
                    Quantity = requestedQuantity,
                    Price_At_Purchase = ProductInInventory.Product.Price
                };
                _context.OrderItems.Add(newOrderItem);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return OrderResult.Success;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Concurrency Failure : Another User Updated Stock for Product Id {ProductId} simultaneously.");
                return OrderResult.ConcurrencyError;
            }
            catch (Exception) 
            { 
                await transaction.RollbackAsync();
                return OrderResult.UnknownError;
            }
        }
    }
}
