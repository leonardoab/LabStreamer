using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStreamer.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_810 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Banda_BandaId",
                        column: x => x.BandaId,
                        principalTable: "Banda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListaFavorita",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavorita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaFavorita_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Musica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musica_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Musica_Banda_BandaId",
                        column: x => x.BandaId,
                        principalTable: "Banda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListaFavoritaMusica",
                columns: table => new
                {
                    ListaFavoritasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavoritaMusica", x => new { x.ListaFavoritasId, x.MusicasId });
                    table.ForeignKey(
                        name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasId",
                        column: x => x.ListaFavoritasId,
                        principalTable: "ListaFavorita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaFavoritaMusica_Musica_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "Musica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_BandaId",
                table: "Album",
                column: "BandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavorita_UsuarioId",
                table: "ListaFavorita",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritaMusica_MusicasId",
                table: "ListaFavoritaMusica",
                column: "MusicasId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_AlbumId",
                table: "Musica",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_BandaId",
                table: "Musica",
                column: "BandaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaFavoritaMusica");

            migrationBuilder.DropTable(
                name: "ListaFavorita");

            migrationBuilder.DropTable(
                name: "Musica");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Banda");
        }
    }
}
