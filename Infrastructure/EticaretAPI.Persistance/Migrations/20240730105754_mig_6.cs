using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EticaretAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_productId",
                table: "Files",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Product_productId",
                table: "Files",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Product_productId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_productId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Files");
        }
    }
}
