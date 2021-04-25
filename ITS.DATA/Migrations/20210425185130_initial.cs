using Microsoft.EntityFrameworkCore.Migrations;

namespace ITS.DATA.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GrupId",
                table: "AspNetUsers",
                column: "GrupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Grup_GrupId",
                table: "AspNetUsers",
                column: "GrupId",
                principalTable: "Grup",
                principalColumn: "GrupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Grup_GrupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GrupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GrupId",
                table: "AspNetUsers");
        }
    }
}
