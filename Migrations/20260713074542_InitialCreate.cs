using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gho_Daung___Order___Inventory_System__.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Inventory_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Inventory_Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price_At_Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.Order_Id, x.Product_Id });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Products",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_Id", "Created_Date", "IsDeleted", "Modified_Date", "Price", "Product_Name", "SKU" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 13, 7, 45, 38, 797, DateTimeKind.Utc).AddTicks(4416), false, null, 4.50m, "Concrete Blocks", "WH-CONC-001" },
                    { 2, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2576), false, null, 12.00m, "Steel Rebar Rods", "WH-STEL-002" },
                    { 3, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2589), false, null, 150.00m, "Heavy Duty Forklift Tires", "WH-TIRE-003" },
                    { 4, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2593), false, null, 8.00m, "Cement Bags 50kg", "WH-CEMT-004" },
                    { 5, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2596), false, null, 35.00m, "Construction Sand (Ton)", "WH-SAND-005" },
                    { 6, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2708), false, null, 45.00m, "Gravel Stone (Ton)", "WH-GRAV-006" },
                    { 7, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2712), false, null, 25.00m, "Wooden Pallets", "WH-PALT-007" },
                    { 8, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2716), false, null, 18.00m, "Safety Helmets", "WH-SAFE-008" },
                    { 9, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2723), false, null, 6.50m, "Industrial Gloves", "WH-GLOV-009" },
                    { 10, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2727), false, null, 120.00m, "Electric Drill Machine", "WH-TOOL-010" },
                    { 11, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2730), false, null, 55.00m, "Steel Pipes", "WH-PIPE-011" },
                    { 12, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2733), false, null, 20.00m, "PVC Water Pipes", "WH-PVC-012" },
                    { 13, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2737), false, null, 40.00m, "Paint Bucket 20L", "WH-PAIN-013" },
                    { 14, new DateTime(2026, 7, 13, 7, 45, 38, 798, DateTimeKind.Utc).AddTicks(2740), false, null, 30.00m, "LED Warehouse Lights", "WH-LITE-014" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Inventory_Id", "Product_Id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 500 },
                    { 2, 2, 250 },
                    { 3, 3, 15 },
                    { 4, 4, 300 },
                    { 5, 5, 50 },
                    { 6, 6, 40 },
                    { 7, 7, 120 },
                    { 8, 8, 200 },
                    { 9, 9, 350 },
                    { 10, 10, 25 },
                    { 11, 11, 100 },
                    { 12, 12, 180 },
                    { 13, 13, 75 },
                    { 14, 14, 60 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Product_Id",
                table: "Inventories",
                column: "Product_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Product_Id",
                table: "OrderItems",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SKU",
                table: "Products",
                column: "SKU",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
