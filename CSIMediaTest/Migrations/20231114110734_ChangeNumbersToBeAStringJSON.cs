using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSIMediaTest.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNumbersToBeAStringJSON : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_SortedNumbersId",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "SortedNumbersId",
                table: "Numbers");

            migrationBuilder.AddColumn<string>(
                name: "Numbers",
                table: "SortedNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numbers",
                table: "SortedNumbers");

            migrationBuilder.AddColumn<int>(
                name: "SortedNumbersId",
                table: "Numbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_SortedNumbersId",
                table: "Numbers",
                column: "SortedNumbersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers",
                column: "SortedNumbersId",
                principalTable: "SortedNumbers",
                principalColumn: "Id");
        }
    }
}
