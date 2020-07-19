using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Campeonato");

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "sigla",
                table: "Time",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10) CHARACTER SET utf8mb4",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Time",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Partida",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataFinal",
                table: "Campeonato",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "codigoCampeonato",
                table: "Campeonato",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Campeonato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "quartoId",
                table: "Campeonato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Time_sigla",
                table: "Time",
                column: "sigla",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_codigoCampeonato",
                table: "Campeonato",
                column: "codigoCampeonato",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campeonato_Time_quartoId",
                table: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Time_sigla",
                table: "Time");

            migrationBuilder.DropIndex(
                name: "IX_Campeonato_codigoCampeonato",
                table: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Campeonato_quartoId",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Time");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Partida");

            migrationBuilder.DropColumn(
                name: "codigoCampeonato",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Campeonato");

            migrationBuilder.DropColumn(
                name: "quartoId",
                table: "Campeonato");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "User",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sigla",
                table: "Time",
                type: "varchar(10) CHARACTER SET utf8mb4",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Time",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Partida",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataFinal",
                table: "Campeonato",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Campeonato",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
