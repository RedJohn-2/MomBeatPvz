using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SomeFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution");

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "TierListSolution",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution");

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "TierListSolution",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
