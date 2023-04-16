using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPlatform_GraduationProject.Data.Migrations
{
    public partial class hamdeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OneDeviceLogin",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneDeviceLogin", x => x.userName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OneDeviceLogin");
        }
    }
}
