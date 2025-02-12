using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_TierList_TierListId",
                table: "TierListSolution");

            migrationBuilder.DropIndex(
                name: "IX_TierListSolution_OwnerId",
                table: "TierListSolution");

            migrationBuilder.DropIndex(
                name: "IX_Team_AuthorId",
                table: "Team");

            migrationBuilder.AlterColumn<long>(
                name: "TierListId",
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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Team_AuthorId_ChampionshipId",
                table: "Team",
                columns: new[] { "AuthorId", "ChampionshipId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_TierList_TierListId",
                table: "TierListSolution",
                column: "TierListId",
                principalTable: "TierList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierListSolution_TierList_TierListId",
                table: "TierListSolution");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TierListSolution_OwnerId_TierListId",
                table: "TierListSolution");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Team_AuthorId_ChampionshipId",
                table: "Team");

            migrationBuilder.AlterColumn<long>(
                name: "TierListId",
                table: "TierListSolution",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_TierListSolution_OwnerId",
                table: "TierListSolution",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_AuthorId",
                table: "Team",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TierListSolution_TierList_TierListId",
                table: "TierListSolution",
                column: "TierListId",
                principalTable: "TierList",
                principalColumn: "Id");
        }
    }
}
