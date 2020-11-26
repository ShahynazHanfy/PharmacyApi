using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrugDetails_drugID",
                table: "DrugDetails");

            migrationBuilder.CreateIndex(
                name: "IX_DrugDetails_drugID",
                table: "DrugDetails",
                column: "drugID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DrugDetails_drugID",
                table: "DrugDetails");

            migrationBuilder.CreateIndex(
                name: "IX_DrugDetails_drugID",
                table: "DrugDetails",
                column: "drugID",
                unique: true);
        }
    }
}
