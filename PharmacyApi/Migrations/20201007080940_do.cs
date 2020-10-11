using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApi.Migrations
{
    public partial class @do : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "pledgeID",
                table: "Order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    pharmacyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Pharmacy_pharmacyID",
                        column: x => x.pharmacyID,
                        principalTable: "Pharmacy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_pharmacyID",
                table: "Employee",
                column: "pharmacyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order",
                column: "pledgeID",
                principalTable: "Pledge",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "pledgeID",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Pledge_pledgeID",
                table: "Order",
                column: "pledgeID",
                principalTable: "Pledge",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
