using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierList_Championship_Id",
                table: "TierList");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TierList",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "TierListId",
                table: "Championship",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Championship_TierListId",
                table: "Championship",
                column: "TierListId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Championship_TierList_TierListId",
                table: "Championship",
                column: "TierListId",
                principalTable: "TierList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championship_TierList_TierListId",
                table: "Championship");

            migrationBuilder.DropIndex(
                name: "IX_Championship_TierListId",
                table: "Championship");

            migrationBuilder.DropColumn(
                name: "TierListId",
                table: "Championship");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TierList",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_TierList_Championship_Id",
                table: "TierList",
                column: "Id",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
