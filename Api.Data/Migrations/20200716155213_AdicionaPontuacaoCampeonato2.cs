using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionaPontuacaoCampeonato2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PontuacaoCampeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    timeId = table.Column<Guid>(nullable: true),
                    codigoCampeonato = table.Column<string>(nullable: true),
                    pontuacaoTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontuacaoCampeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontuacaoCampeonato_Time_timeId",
                        column: x => x.timeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PontuacaoCampeonato_timeId",
                table: "PontuacaoCampeonato",
                column: "timeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PontuacaoCampeonato");
        }
    }
}
