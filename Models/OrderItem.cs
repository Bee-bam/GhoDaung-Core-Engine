using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gho_Daung___Order___Inventory_System__.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product? Product { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public decimal Price_At_Purchase { get; set; }

    }
}
