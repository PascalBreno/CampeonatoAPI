using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveQuartoTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campeonato_Time_quartoId",
                table: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Campeonato_quartoId",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "quartoId",
                table: "Campeonato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "quartoId",
                table: "Campeonato",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_quartoId",
                table: "Campeonato",
                column: "quartoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campeonato_Time_quartoId",
                table: "Campeonato",
                column: "quartoId",
                principalTable: "Time",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
