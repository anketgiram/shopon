using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EkartEF.Migrations
{
    public partial class initOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customer",
            //    columns: table => new
            //    {
            //        CustomerId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        CustomerEmailID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        CustomerMobileNO = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
            //        AppCustomerID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customer", x => x.CustomerId);
            //    });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusId);
                });

            //migrationBuilder.CreateTable(
            //    name: "CustomerAddress",
            //    columns: table => new
            //    {
            //        CustomerAddressID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
            //        CustomerId = table.Column<int>(type: "int", nullable: true),
            //        isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerAddress", x => x.CustomerAddressID);
            //        table.ForeignKey(
            //            name: "FK__CustomerA__Custo__47DBAE45",
            //            column: x => x.CustomerId,
            //            principalTable: "Customer",
            //            principalColumn: "CustomerId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "Orderd",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientOrderId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: false),
                    ExceptedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderd", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orderd_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderd_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Orderid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orderd_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orderd",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderd_CustomerId",
                table: "Orderd",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderd_OrderStatusId",
                table: "Orderd",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Orderid",
                table: "OrderItems",
                column: "Orderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orderd");

            //migrationBuilder.DropTable(
            //    name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderStatus");
        }
    }
}
