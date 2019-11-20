using Microsoft.EntityFrameworkCore.Migrations;

namespace website.Migrations
{
    public partial class AddNumberTableWaitingLines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "WaitingLines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "WaitingLines");
        }
    }
}
