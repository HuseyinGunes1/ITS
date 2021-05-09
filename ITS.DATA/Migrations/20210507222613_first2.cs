using Microsoft.EntityFrameworkCore.Migrations;

namespace ITS.DATA.Migrations
{
    public partial class first2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "IsUcreti",
                table: "Ucret",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,3)",
                oldUnicode: false,
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "IsUcreti",
                table: "Ucret",
                type: "decimal(5,3)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
