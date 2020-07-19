using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionaPontuacaoCampeonato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampeonatoEntityId",
                table: "Partida",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partida_CampeonatoEntityId",
                table: "Partida",
                column: "CampeonatoEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partida_Campeonato_CampeonatoEntityId",
                table: "Partida",
                column: "CampeonatoEntityId",
                principalTable: "Campeonato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partida_Campeonato_CampeonatoEntityId",
                table: "Partida");

            migrationBuilder.DropIndex(
                name: "IX_Partida_CampeonatoEntityId",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "CampeonatoEntityId",
                table: "Partida");
        }
    }
}
