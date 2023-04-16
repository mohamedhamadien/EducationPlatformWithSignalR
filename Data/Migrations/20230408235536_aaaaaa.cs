using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationPlatform_GraduationProject.Data.Migrations
{
    public partial class aaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserID",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdentityUserID",
                table: "Students",
                column: "IdentityUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserID",
                table: "Students",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_IdentityUserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdentityUserID",
                table: "Students");
        }
    }
}
