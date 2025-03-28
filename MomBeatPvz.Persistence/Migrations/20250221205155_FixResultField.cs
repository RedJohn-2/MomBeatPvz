﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MomBeatPvz.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixResultField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierList_TierListSolution_ResultId",
                table: "TierList");

            migrationBuilder.AlterColumn<long>(
                name: "ResultId",
                table: "TierList",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_TierList_TierListSolution_ResultId",
                table: "TierList",
                column: "ResultId",
                principalTable: "TierListSolution",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TierList_TierListSolution_ResultId",
                table: "TierList");

            migrationBuilder.AlterColumn<long>(
                name: "ResultId",
                table: "TierList",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TierList_TierListSolution_ResultId",
                table: "TierList",
                column: "ResultId",
                principalTable: "TierListSolution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
