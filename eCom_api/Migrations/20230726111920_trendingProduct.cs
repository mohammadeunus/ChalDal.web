using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom_api.Migrations
{
    /// <inheritdoc />
    public partial class trendingProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "product");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trendingProducts");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
