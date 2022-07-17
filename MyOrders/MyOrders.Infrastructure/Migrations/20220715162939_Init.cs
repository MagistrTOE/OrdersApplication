using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyOrders.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderCity = table.Column<string>(type: "text", nullable: false),
                    SenderAddress = table.Column<string>(type: "text", nullable: false),
                    RecipientCity = table.Column<string>(type: "text", nullable: false),
                    RecipientAddress = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    RecivedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
