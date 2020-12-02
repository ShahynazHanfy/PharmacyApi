using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class aaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "patientId",
                table: "Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_patientId",
                table: "Order",
                column: "patientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Patients_patientId",
                table: "Order",
                column: "patientId",
                principalTable: "Patients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Patients_patientId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_patientId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "patientId",
                table: "Order");
        }
    }
}
