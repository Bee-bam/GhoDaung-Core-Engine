using System.ComponentModel.DataAnnotations;

namespace Gho_Daung___Order___Inventory_System__.Models
{
    public class Product : IAuditable, ISoftDelete
    {
        public int Product_Id { get; set; }

        [Required(ErrorMessage = "Product_Name required !!")]
        [StringLength(100, ErrorMessage = " Product_name is less than 100 ")]
        public string Product_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Need Amount!!")]
        [Range (0.01,999999.99 , ErrorMessage = "Amount is Greater than 0 ")]
        public decimal Price { get; set; }
        public string SKU { get; set; }

        public Inventory? Inventory { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.UtcNow;
        public DateTime? Modified_Date { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
