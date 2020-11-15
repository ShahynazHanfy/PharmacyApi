using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class ewq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quentity",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "QuentityInEachOrder",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuentityInEachOrder",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "Quentity",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
