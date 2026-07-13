using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gho_Daung___Order___Inventory_System__.Models
{
    public class Inventory
    {
        public int Inventory_Id { get; set; }

        [Required (ErrorMessage ="ပစ္စည်းအရေ အတွက်ထည့်အုံး")]
        [Range(1, int.MaxValue , ErrorMessage = "ပစ္စည်းအရေအတွက်က  0 ထက်များရပါမယ်နော် ")]
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public int Product_Id {  get; set; }
        public Product? Product { get; set; }
            
  
    }
}
