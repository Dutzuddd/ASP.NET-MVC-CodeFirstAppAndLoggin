using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_1_Sfranciog.Migrations.AppData
{
    public partial class ProceseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Procese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Ora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rezultat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_dosar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procese", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procese");
        }
    }
}
