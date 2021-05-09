using Microsoft.EntityFrameworkCore.Migrations;

namespace ITS.DATA.Migrations
{
    public partial class first3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Yövmiye",
                table: "IsIsci",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Yövmiye",
                table: "IsIsci",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
