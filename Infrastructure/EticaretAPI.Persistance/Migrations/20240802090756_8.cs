using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "ShopAssistants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "ShopAssistants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
