using Microsoft.EntityFrameworkCore.Migrations;

namespace Day2.Migrations
{
    public partial class updateCrsResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TraineeID",
                table: "CrsResult");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraineeID",
                table: "CrsResult",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
