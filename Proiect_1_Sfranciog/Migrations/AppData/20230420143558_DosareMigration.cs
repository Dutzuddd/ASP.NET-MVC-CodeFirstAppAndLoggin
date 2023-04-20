using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_1_Sfranciog.Migrations.AppData
{
    public partial class DosareMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosare_Clienti_Clienti",
                table: "Dosare");

            migrationBuilder.DropIndex(
                name: "IX_Dosare_Clienti",
                table: "Dosare");

            migrationBuilder.RenameColumn(
                name: "Clienti",
                table: "Dosare",
                newName: "Id_Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_Client",
                table: "Dosare",
                newName: "Clienti");

            migrationBuilder.CreateIndex(
                name: "IX_Dosare_Clienti",
                table: "Dosare",
                column: "Clienti");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosare_Clienti_Clienti",
                table: "Dosare",
                column: "Clienti",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
