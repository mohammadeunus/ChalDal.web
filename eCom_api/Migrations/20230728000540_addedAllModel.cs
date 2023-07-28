using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom_api.Migrations
{
    /// <inheritdoc />
    public partial class addedAllModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerModel",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModel", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "trendingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PopularityCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trendingProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", maxLength: 100, nullable: false),
                    DiscountStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiscountEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDiscounted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_product_Categories_CategoryRefId",
                        column: x => x.CategoryRefId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReviewModel",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductRefId = table.Column<int>(type: "int", nullable: false),
                    CustomerRefId = table.Column<int>(type: "int", nullable: false),
                    CustomerModel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewModel", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_ReviewModel_CustomerModel_CustomerModel",
                        column: x => x.CustomerModel,
                        principalTable: "CustomerModel",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_ReviewModel_product_ProductRefId",
                        column: x => x.ProductRefId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_stocks_product_ProductRefId",
                        column: x => x.ProductRefId,
                        principalTable: "product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryRefId",
                table: "product",
                column: "CategoryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewModel_CustomerModel",
                table: "ReviewModel",
                column: "CustomerModel");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewModel_ProductRefId",
                table: "ReviewModel",
                column: "ProductRefId");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_ProductRefId",
                table: "stocks",
                column: "ProductRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewModel");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "trendingProducts");

            migrationBuilder.DropTable(
                name: "CustomerModel");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
