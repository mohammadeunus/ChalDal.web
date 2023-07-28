using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCom_api.Migrations
{
    /// <inheritdoc />
    public partial class removedDuplicateInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "ReviewModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomerModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewDate",
                table: "ReviewModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CustomerModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
