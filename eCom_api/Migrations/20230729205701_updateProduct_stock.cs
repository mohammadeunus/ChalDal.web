using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom_api.Migrations
{
    /// <inheritdoc />
    public partial class updateProduct_stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryModelCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockRefId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockRefId",
                table: "Products",
                column: "StockRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stocks_StockRefId",
                table: "Products",
                column: "StockRefId",
                principalTable: "Stocks",
                principalColumn: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stocks_StockRefId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockRefId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockRefId",
                table: "Products");
        }
    }
}
