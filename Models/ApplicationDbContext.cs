using Gho_Daung___Order___Inventory_System__.Models;
using Microsoft.EntityFrameworkCore;
    
namespace Gho_Daung___Order___Inventory_System__.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Product)
                .HasForeignKey<Inventory>(i => i.Product_Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Product_Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Order_Id);

            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.Inventory_Id);

            modelBuilder.Entity<Order>()
                .Property(o => o.Total_Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.Order_Id, oi.Product_Id });

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price_At_Purchase)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Inventory>()
                .HasQueryFilter(i => !i.Product.IsDeleted);

            modelBuilder.Entity<OrderItem>()
                .HasQueryFilter(oi => !oi.Product.IsDeleted);

            var seedDate = new DateTime(2026,1,1,0,0,0, DateTimeKind.Utc);

            modelBuilder.Entity<Product>().HasData(
                new Product { Product_Id = 1, Product_Name = "Concrete Blocks", Price = 4.50m, SKU = "WH-CONC-001", Created_Date = seedDate },
                new Product { Product_Id = 2, Product_Name = "Steel Rebar Rods", Price = 12.00m, SKU = "WH-STEL-002", Created_Date = seedDate },
                new Product { Product_Id = 3, Product_Name = "Heavy Duty Forklift Tires", Price = 150.00m, SKU = "WH-TIRE-003", Created_Date = seedDate },
                new Product { Product_Id = 4, Product_Name = "Cement Bags 50kg", Price = 8.00m, SKU = "WH-CEMT-004", Created_Date = seedDate },
                new Product { Product_Id = 5, Product_Name = "Construction Sand (Ton)", Price = 35.00m, SKU = "WH-SAND-005", Created_Date = seedDate },
                new Product { Product_Id = 6, Product_Name = "Gravel Stone (Ton)", Price = 45.00m, SKU = "WH-GRAV-006", Created_Date = seedDate },
                new Product { Product_Id = 7, Product_Name = "Wooden Pallets", Price = 25.00m, SKU = "WH-PALT-007", Created_Date = seedDate },
                new Product { Product_Id = 8, Product_Name = "Safety Helmets", Price = 18.00m, SKU = "WH-SAFE-008", Created_Date = seedDate },
                new Product { Product_Id = 9, Product_Name = "Industrial Gloves", Price = 6.50m, SKU = "WH-GLOV-009", Created_Date = seedDate },
                new Product { Product_Id = 10, Product_Name = "Electric Drill Machine", Price = 120.00m, SKU = "WH-TOOL-010", Created_Date = seedDate },
                new Product { Product_Id = 11, Product_Name = "Steel Pipes", Price = 55.00m, SKU = "WH-PIPE-011", Created_Date = seedDate },
                new Product { Product_Id = 12, Product_Name = "PVC Water Pipes", Price = 20.00m, SKU = "WH-PVC-012", Created_Date = seedDate },
                new Product { Product_Id = 13, Product_Name = "Paint Bucket 20L", Price = 40.00m, SKU = "WH-PAIN-013", Created_Date = seedDate },
                new Product { Product_Id = 14, Product_Name = "LED Warehouse Lights", Price = 30.00m, SKU = "WH-LITE-014", Created_Date = seedDate }
            );

            modelBuilder.Entity<Inventory>().HasData(
                new Inventory { Inventory_Id = 1, Product_Id = 1, Quantity = 500 },
                new Inventory { Inventory_Id = 2, Product_Id = 2, Quantity = 250 },
                new Inventory { Inventory_Id = 3, Product_Id = 3, Quantity = 15 },
                new Inventory { Inventory_Id = 4, Product_Id = 4, Quantity = 300 },
                new Inventory { Inventory_Id = 5, Product_Id = 5, Quantity = 50 },
                new Inventory { Inventory_Id = 6, Product_Id = 6, Quantity = 40 },
                new Inventory { Inventory_Id = 7, Product_Id = 7, Quantity = 120 },
                new Inventory { Inventory_Id = 8, Product_Id = 8, Quantity = 200 },
                new Inventory { Inventory_Id = 9, Product_Id = 9, Quantity = 350 },
                new Inventory { Inventory_Id = 10, Product_Id = 10, Quantity = 25 },
                new Inventory { Inventory_Id = 11, Product_Id = 11, Quantity = 100 },
                new Inventory { Inventory_Id = 12, Product_Id = 12, Quantity = 180 },
                new Inventory { Inventory_Id = 13, Product_Id = 13, Quantity = 75 },
                new Inventory { Inventory_Id = 14, Product_Id = 14, Quantity = 60 }
            );
        }
    }
}
