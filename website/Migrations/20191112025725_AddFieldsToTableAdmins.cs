using Microsoft.EntityFrameworkCore.Migrations;

namespace website.Migrations
{
    public partial class AddFieldsToTableAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameFirst",
                table: "Admins",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameLast",
                table: "Admins",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameMiddle",
                table: "Admins",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameFirst",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NameLast",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NameMiddle",
                table: "Admins");
        }
    }
}
