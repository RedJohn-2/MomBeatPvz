using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAltKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TierListSolution_OwnerId_TierListId",
                table: "TierListSolution");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "TierListSolution",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_TierListSolution_OwnerId",
                table: "TierListSolution",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution");

            migrationBuilder.DropIndex(
                name: "IX_TierListSolution_OwnerId",
                table: "TierListSolution");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "TierListSolution",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TierListSolution_OwnerId_TierListId",
                table: "TierListSolution",
                columns: new[] { "OwnerId", "TierListId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_User_OwnerId",
                table: "TierListSolution",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
