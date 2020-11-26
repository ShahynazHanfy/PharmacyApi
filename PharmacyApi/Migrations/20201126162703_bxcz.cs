using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class bxcz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Drug_drugID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "drugID",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Drug_drugID",
                table: "OrderDetails",
                column: "drugID",
                principalTable: "Drug",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Drug_drugID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "drugID",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Drug_drugID",
                table: "OrderDetails",
                column: "drugID",
                principalTable: "Drug",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
