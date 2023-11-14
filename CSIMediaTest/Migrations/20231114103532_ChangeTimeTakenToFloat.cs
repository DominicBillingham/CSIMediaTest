using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSIMediaTest.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTimeTakenToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers");

            migrationBuilder.AlterColumn<float>(
                name: "TimeTakenToSort",
                table: "SortedNumbers",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SortedNumbersId",
                table: "Numbers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers",
                column: "SortedNumbersId",
                principalTable: "SortedNumbers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers");

            migrationBuilder.AlterColumn<int>(
                name: "TimeTakenToSort",
                table: "SortedNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "SortedNumbersId",
                table: "Numbers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                table: "Numbers",
                column: "SortedNumbersId",
                principalTable: "SortedNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
