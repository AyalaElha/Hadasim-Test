using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Covid.Data.Migrations
{
    public partial class tehila4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Covids_CovidDetailsId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members");

            migrationBuilder.CreateIndex(
                name: "IX_Covids_MemberId",
                table: "Covids",
                column: "MemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Covids_Members_MemberId",
                table: "Covids",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covids_Members_MemberId",
                table: "Covids");

            migrationBuilder.DropIndex(
                name: "IX_Covids_MemberId",
                table: "Covids");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CovidDetailsId",
                table: "Members",
                column: "CovidDetailsId",
                unique: true,
                filter: "[CovidDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Covids_CovidDetailsId",
                table: "Members",
                column: "CovidDetailsId",
                principalTable: "Covids",
                principalColumn: "Id");
        }
    }
}
