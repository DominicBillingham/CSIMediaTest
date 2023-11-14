using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSIMediaTest.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SortedNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeTakenToSort = table.Column<int>(type: "int", nullable: false),
                    InAscendingOrder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortedNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SortedNumbersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Numbers_SortedNumbers_SortedNumbersId",
                        column: x => x.SortedNumbersId,
                        principalTable: "SortedNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_SortedNumbersId",
                table: "Numbers",
                column: "SortedNumbersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");

            migrationBuilder.DropTable(
                name: "SortedNumbers");
        }
    }
}
