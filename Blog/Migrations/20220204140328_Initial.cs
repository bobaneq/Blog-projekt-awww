using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tagi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wpisy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zawartosc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KomentarzeZablokowane = table.Column<bool>(type: "bit", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpisy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Komentarze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WpisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentarze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentarze_Wpisy_WpisId",
                        column: x => x.WpisId,
                        principalTable: "Wpisy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oceny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WpisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oceny", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oceny_Wpisy_WpisId",
                        column: x => x.WpisId,
                        principalTable: "Wpisy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagiWpisy",
                columns: table => new
                {
                    WpisId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagiWpisy", x => new { x.WpisId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagiWpisy_Tagi_TagId",
                        column: x => x.TagId,
                        principalTable: "Tagi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagiWpisy_Wpisy_WpisId",
                        column: x => x.WpisId,
                        principalTable: "Wpisy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentarze_WpisId",
                table: "Komentarze",
                column: "WpisId");

            migrationBuilder.CreateIndex(
                name: "IX_Oceny_WpisId",
                table: "Oceny",
                column: "WpisId");

            migrationBuilder.CreateIndex(
                name: "IX_TagiWpisy_TagId",
                table: "TagiWpisy",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentarze");

            migrationBuilder.DropTable(
                name: "Oceny");

            migrationBuilder.DropTable(
                name: "TagiWpisy");

            migrationBuilder.DropTable(
                name: "Tagi");

            migrationBuilder.DropTable(
                name: "Wpisy");
        }
    }
}
