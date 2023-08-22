using Microsoft.EntityFrameworkCore.Migrations;

namespace EkartEF.Migrations
{
    public partial class initSeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "OrderStatusId", "Description", "StatusType" },
                values: new object[,]
                {
                    { 1001, "Order Hase been Recevied", "Order Received" },
                    { 1002, "Your Order Picked from Vendor", "Order Picked" },
                    { 1003, "Order shipped from nearnest wearhouse", "Order Shipped" },
                    { 1004, "Your Order is Out for Delivery", "Out for Delivery" },
                    { 1005, "Order Has been Deliverd", "Order Deliverd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "OrderStatusId",
                keyValue: 1005);
        }
    }
}
