using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNet.Data.Migrations
{
    public partial class AppUserProperties1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "AspNetUsers",
                newName: "BirthDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AspNetUsers",
                newName: "birthDate");
        }
    }
}
