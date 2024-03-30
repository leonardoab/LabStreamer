using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStreamer.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_186 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanoId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PlanoId",
                table: "Usuario",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Plano_PlanoId",
                table: "Usuario",
                column: "PlanoId",
                principalTable: "Plano",
                principalColumn: "IdPlano",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Plano_PlanoId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PlanoId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Usuario");
        }
    }
}
