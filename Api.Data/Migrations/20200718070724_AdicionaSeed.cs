using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionaSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("ca69a3fe-4622-4a5d-bff2-27c99d5ffc0a"));

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "isDeleted", "nome", "sigla" },
                values: new object[,]
                {
                    { new Guid("115a2a89-2fed-413d-a09e-dec1fc266f00"), new DateTime(2020, 7, 18, 3, 7, 24, 520, DateTimeKind.Local).AddTicks(7116), false, "Palmeiras", "PLM" },
                    { new Guid("863b8bca-9b54-4e94-bd58-453ef68293cf"), new DateTime(2020, 7, 18, 3, 7, 24, 522, DateTimeKind.Local).AddTicks(7970), false, "São Paulo", "SP" },
                    { new Guid("547cc278-a37b-4e8a-a5c5-22db1f35584f"), new DateTime(2020, 7, 18, 3, 7, 24, 522, DateTimeKind.Local).AddTicks(8075), false, "Flamento", "FLM" },
                    { new Guid("76073bbd-5e08-4e24-9191-ee6c6d7762d8"), new DateTime(2020, 7, 18, 3, 7, 24, 522, DateTimeKind.Local).AddTicks(8083), false, "Bota Fogo", "BTF" },
                    { new Guid("de2dd757-a014-4ebb-b84a-5df5104630df"), new DateTime(2020, 7, 18, 3, 7, 24, 522, DateTimeKind.Local).AddTicks(8090), false, "Grêmio", "GRM" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("115a2a89-2fed-413d-a09e-dec1fc266f00"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("547cc278-a37b-4e8a-a5c5-22db1f35584f"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("76073bbd-5e08-4e24-9191-ee6c6d7762d8"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("863b8bca-9b54-4e94-bd58-453ef68293cf"));

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Id",
                keyValue: new Guid("de2dd757-a014-4ebb-b84a-5df5104630df"));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    email = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false),
                    isDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    nome = table.Column<string>(type: "varchar(60) CHARACTER SET utf8mb4", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Id", "CreateAt", "isDeleted", "nome", "sigla" },
                values: new object[] { new Guid("ca69a3fe-4622-4a5d-bff2-27c99d5ffc0a"), null, false, "Palmeiras", "PLM" });

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);
        }
    }
}
