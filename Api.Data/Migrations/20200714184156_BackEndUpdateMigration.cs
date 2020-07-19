using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class BackEndUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    sigla = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    nome = table.Column<string>(maxLength: 1000, nullable: true),
                    dataInicio = table.Column<DateTime>(nullable: false),
                    dataFinal = table.Column<DateTime>(nullable: false),
                    campeaoId = table.Column<Guid>(nullable: true),
                    viciId = table.Column<Guid>(nullable: true),
                    terceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_campeaoId",
                        column: x => x.campeaoId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_terceiroId",
                        column: x => x.terceiroId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_viciId",
                        column: x => x.viciId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    timeAId = table.Column<Guid>(nullable: true),
                    timeBId = table.Column<Guid>(nullable: true),
                    golsA = table.Column<int>(nullable: false),
                    golsB = table.Column<int>(nullable: false),
                    data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partida_Time_timeAId",
                        column: x => x.timeAId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partida_Time_timeBId",
                        column: x => x.timeBId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_campeaoId",
                table: "Campeonato",
                column: "campeaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_terceiroId",
                table: "Campeonato",
                column: "terceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_viciId",
                table: "Campeonato",
                column: "viciId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_timeAId",
                table: "Partida",
                column: "timeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_timeBId",
                table: "Partida",
                column: "timeBId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
