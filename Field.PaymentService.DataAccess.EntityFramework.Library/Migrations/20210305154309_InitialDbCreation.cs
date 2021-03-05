using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Field.PaymentService.DataAccess.EntityFramework.Library.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CardHolder = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: false),
                    SecurityCode = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
