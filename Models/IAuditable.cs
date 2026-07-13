namespace Gho_Daung___Order___Inventory_System__.Models
{
    public interface IAuditable
    {
        public DateTime Created_Date { get; set; }
        public DateTime? Modified_Date { get; set; }
    }
}
