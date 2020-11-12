using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class mhgerdqqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_pledgeId",
                table: "Order",
                column: "pledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pledge_pledgeId",
                table: "Order",
                column: "pledgeId",
                principalTable: "Pledge",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pledge_pledgeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_pledgeId",
                table: "Order");
        }
    }
}
