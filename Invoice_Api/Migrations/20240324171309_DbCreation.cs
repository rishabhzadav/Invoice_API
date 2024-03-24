using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice_Api.Migrations
{
    public partial class DbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    InvoiceDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceCustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceCustomerMno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceNo);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemDiscountInPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(21)", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ItemQty = table.Column<int>(type: "int", nullable: false),
                    ItemUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemAmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => new { x.InvoiceNo, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceNo",
                        column: x => x.InvoiceNo,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
