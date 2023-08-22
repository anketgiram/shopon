using Microsoft.EntityFrameworkCore.Migrations;

namespace EkartEF.Migrations
{
    public partial class initStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerId",
                table: "CustomerAddress");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress");

            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "Orderd",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "CustomerAddress",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orderd_StaffId",
                table: "Orderd",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId1",
                table: "CustomerAddress",
                column: "CustomerId1",
                unique: true,
                filter: "[CustomerId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK__CustomerA__Custo__47DBAE45",
                table: "CustomerAddress",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerId1",
                table: "CustomerAddress",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderd_AspNetUsers_StaffId",
                table: "Orderd",
                column: "StaffId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__CustomerA__Custo__47DBAE45",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerId1",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderd_AspNetUsers_StaffId",
                table: "Orderd");

            migrationBuilder.DropIndex(
                name: "IX_Orderd_StaffId",
                table: "Orderd");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddress_CustomerId1",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Orderd");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_Customer_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
