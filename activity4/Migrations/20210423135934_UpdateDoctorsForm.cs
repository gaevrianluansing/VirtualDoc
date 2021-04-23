using Microsoft.EntityFrameworkCore.Migrations;

namespace activity4.Migrations
{
    public partial class UpdateDoctorsForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNum",
                table: "Doctorsforms");

            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "Doctorsforms");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorType",
                table: "Doctorsforms",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Doctorsforms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctorsforms_UserId",
                table: "Doctorsforms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctorsforms_AspNetUsers_UserId",
                table: "Doctorsforms",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctorsforms_AspNetUsers_UserId",
                table: "Doctorsforms");

            migrationBuilder.DropIndex(
                name: "IX_Doctorsforms_UserId",
                table: "Doctorsforms");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Doctorsforms");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorType",
                table: "Doctorsforms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ContactNum",
                table: "Doctorsforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "Doctorsforms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
