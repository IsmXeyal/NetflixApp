using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetflixAppDataAccessLayer.Migrations
{
    public partial class Mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBoth",
                table: "AddListTTs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoth",
                table: "AddListTMs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoth",
                table: "AddListMpTs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoth",
                table: "AddListMPMs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBoth",
                table: "AddListECs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBoth",
                table: "AddListTTs");

            migrationBuilder.DropColumn(
                name: "IsBoth",
                table: "AddListTMs");

            migrationBuilder.DropColumn(
                name: "IsBoth",
                table: "AddListMpTs");

            migrationBuilder.DropColumn(
                name: "IsBoth",
                table: "AddListMPMs");

            migrationBuilder.DropColumn(
                name: "IsBoth",
                table: "AddListECs");
        }
    }
}
