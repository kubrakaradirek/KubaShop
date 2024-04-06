using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KubaShop.Discount.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rade",
                table: "Coupons",
                newName: "Rate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Coupons",
                newName: "Rade");
        }
    }
}
