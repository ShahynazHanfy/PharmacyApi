using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class frtyytss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strength = table.Column<string>(nullable: true),
                    Pack = table.Column<string>(nullable: true),
                    License = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    ReOrderLevel = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    Prod_Date = table.Column<DateTime>(nullable: false),
                    Exp_Date = table.Column<DateTime>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    drugID = table.Column<int>(nullable: false),
                    pharmacyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DrugDetails_Drug_drugID",
                        column: x => x.drugID,
                        principalTable: "Drug",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugDetails_Pharmacy_pharmacyID",
                        column: x => x.pharmacyID,
                        principalTable: "Pharmacy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrugDetails_drugID",
                table: "DrugDetails",
                column: "drugID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugDetails_pharmacyID",
                table: "DrugDetails",
                column: "pharmacyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugDetails");
        }
    }
}
