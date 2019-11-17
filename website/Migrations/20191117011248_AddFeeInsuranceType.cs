using Microsoft.EntityFrameworkCore.Migrations;

namespace website.Migrations
{
    public partial class AddFeeInsuranceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fee",
                table: "InsuranceTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "InsuranceTypes");
        }
    }
}
