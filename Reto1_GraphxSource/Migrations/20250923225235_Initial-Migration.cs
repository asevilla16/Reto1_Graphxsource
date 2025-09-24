using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reto1.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityInMl = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeightCm = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    WidthCm = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    PaperType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TShirts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TShirts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TShirtId = table.Column<int>(type: "int", nullable: true),
                    MugId = table.Column<int>(type: "int", nullable: true),
                    PosterId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Mugs_MugId",
                        column: x => x.MugId,
                        principalTable: "Mugs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Posters_PosterId",
                        column: x => x.PosterId,
                        principalTable: "Posters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_TShirts_TShirtId",
                        column: x => x.TShirtId,
                        principalTable: "TShirts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mugs",
                columns: new[] { "Id", "CapacityInMl", "Color", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, 350, "White", 12.99m, "MG001" },
                    { 2, 500, "Black", 14.99m, "MG002" },
                    { 3, 300, "Blue", 11.99m, "MG003" },
                    { 4, 400, "Red", 13.99m, "MG004" },
                    { 5, 600, "Gray", 16.99m, "MG005" }
                });

            migrationBuilder.InsertData(
                table: "Posters",
                columns: new[] { "Id", "HeightCm", "PaperType", "Price", "Sku", "WidthCm" },
                values: new object[,]
                {
                    { 1, 40.0m, "Glossy", 8.99m, "PS001", 30.0m },
                    { 2, 60.0m, "Matte", 12.99m, "PS002", 40.0m },
                    { 3, 80.0m, "Canvas", 24.99m, "PS003", 60.0m },
                    { 4, 50.0m, "Photo Paper", 15.99m, "PS004", 35.0m },
                    { 5, 100.0m, "Vinyl", 34.99m, "PS005", 70.0m }
                });

            migrationBuilder.InsertData(
                table: "TShirts",
                columns: new[] { "Id", "Color", "Price", "Size", "Sku" },
                values: new object[,]
                {
                    { 1, "Red", 15.99m, "S", "TS001" },
                    { 2, "Blue", 15.99m, "M", "TS002" },
                    { 3, "Black", 17.99m, "L", "TS003" },
                    { 4, "White", 17.99m, "XL", "TS004" },
                    { 5, "Green", 16.99m, "M", "TS005" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Client", "CreatedAt", "Description", "MugId", "PosterId", "Status", "TShirtId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Alice", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black T-Shirt order", null, null, 0, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Bob", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Mug order", 3, null, 4, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Charlie", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glossy Poster order", null, 5, 3, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "Id", "OrderId", "Type", "Url" },
                values: new object[,]
                {
                    { 1, 1, 3, "https://example.com/files/design1.png" },
                    { 2, 3, 1, "https://example.com/files/poster-proof.pdf" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_OrderId",
                table: "Attachments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MugId",
                table: "Orders",
                column: "MugId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PosterId",
                table: "Orders",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TShirtId",
                table: "Orders",
                column: "TShirtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Mugs");

            migrationBuilder.DropTable(
                name: "Posters");

            migrationBuilder.DropTable(
                name: "TShirts");
        }
    }
}
