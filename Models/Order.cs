using System.ComponentModel.DataAnnotations;

namespace Gho_Daung___Order___Inventory_System__.Models
{
    public class Order
    {
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; } = DateTime.Now;
        [Required]
        [Range(0.01, 999999.99)]
        public decimal Total_Amount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
