using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabyTravel.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToBabyIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Baby_Name",
                table: "Baby");

            migrationBuilder.CreateIndex(
                name: "IX_Baby_Name_UserId",
                table: "Baby",
                columns: new[] { "Name", "UserId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Baby_Name_UserId",
                table: "Baby");

            migrationBuilder.CreateIndex(
                name: "IX_Baby_Name",
                table: "Baby",
                column: "Name",
                unique: true);
        }
    }
}
