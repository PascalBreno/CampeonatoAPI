using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TesteSeedInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "isDeleted", "nome", "sigla" },
                values: new object[] { new Guid("ca69a3fe-4622-4a5d-bff2-27c99d5ffc0a"), null, false, "Palmeiras", "PLM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("ca69a3fe-4622-4a5d-bff2-27c99d5ffc0a"));
        }
    }
}
