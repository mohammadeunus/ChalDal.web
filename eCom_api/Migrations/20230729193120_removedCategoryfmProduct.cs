using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom_api.Migrations
{
    /// <inheritdoc />
    public partial class removedCategoryfmProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryRefId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryRefId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryModelCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products",
                column: "CategoryModelCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryModelCategoryId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryRefId",
                table: "Products",
                column: "CategoryRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryRefId",
                table: "Products",
                column: "CategoryRefId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
