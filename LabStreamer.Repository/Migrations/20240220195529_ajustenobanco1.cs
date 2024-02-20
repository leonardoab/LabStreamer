using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStreamer.Repository.Migrations
{
    public partial class ajustenobanco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavorita_Conta_UsuarioId",
                table: "ListaFavorita");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conta",
                table: "Conta");

            migrationBuilder.RenameTable(
                name: "Conta",
                newName: "Usuario");

            migrationBuilder.AddColumn<Guid>(
                name: "BandaId",
                table: "Musica",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_BandaId",
                table: "Musica",
                column: "BandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioId",
                table: "ListaFavorita",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Banda_BandaId",
                table: "Musica",
                column: "BandaId",
                principalTable: "Banda",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioId",
                table: "ListaFavorita");

            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Banda_BandaId",
                table: "Musica");

            migrationBuilder.DropIndex(
                name: "IX_Musica_BandaId",
                table: "Musica");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "BandaId",
                table: "Musica");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Conta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conta",
                table: "Conta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavorita_Conta_UsuarioId",
                table: "ListaFavorita",
                column: "UsuarioId",
                principalTable: "Conta",
                principalColumn: "Id");
        }
    }
}
