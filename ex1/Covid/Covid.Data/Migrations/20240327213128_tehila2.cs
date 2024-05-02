using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid.Data.Migrations
{
    public partial class tehila2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Covids");

            migrationBuilder.AlterColumn<int>(
                name: "CovidDetailsId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members",
                column: "CovidDetailsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "CovidDetailsId",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Covids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members",
                column: "CovidDetailsId",
                unique: true,
                filter: "[CovidDetailsId] IS NOT NULL");
        }
    }
}
