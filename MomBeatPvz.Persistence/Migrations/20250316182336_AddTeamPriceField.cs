using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamPriceField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamPrice",
                table: "Championship",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamPrice",
                table: "Championship");
        }
    }
}
