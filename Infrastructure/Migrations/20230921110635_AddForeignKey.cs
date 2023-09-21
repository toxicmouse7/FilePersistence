using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OneTimeFileLinks_FileId",
                table: "OneTimeFileLinks",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OneTimeFileLinks_Files_FileId",
                table: "OneTimeFileLinks",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneTimeFileLinks_Files_FileId",
                table: "OneTimeFileLinks");

            migrationBuilder.DropIndex(
                name: "IX_OneTimeFileLinks_FileId",
                table: "OneTimeFileLinks");
        }
    }
}
