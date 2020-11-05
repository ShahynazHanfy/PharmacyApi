using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class iid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_pledgeID",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_pledgeID",
                table: "Order",
                column: "pledgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order",
                column: "pledgeID",
                principalTable: "Pledge",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
