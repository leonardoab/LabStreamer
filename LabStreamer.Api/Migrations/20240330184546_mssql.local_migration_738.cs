using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStreamer.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_738 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banda",
                columns: table => new
                {
                    IdBanda = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banda", x => x.IdBanda);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    IdPlano = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.IdPlano);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BandaIdBanda = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_Banda_BandaIdBanda",
                        column: x => x.BandaIdBanda,
                        principalTable: "Banda",
                        principalColumn: "IdBanda");
                });

            migrationBuilder.CreateTable(
                name: "ListaFavorita",
                columns: table => new
                {
                    IdListaFavorita = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavorita", x => x.IdListaFavorita);
                    table.ForeignKey(
                        name: "FK_ListaFavorita_Usuario_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Musica",
                columns: table => new
                {
                    IdMusica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumIdAlbum = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BandaIdBanda = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musica", x => x.IdMusica);
                    table.ForeignKey(
                        name: "FK_Musica_Album_AlbumIdAlbum",
                        column: x => x.AlbumIdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum");
                    table.ForeignKey(
                        name: "FK_Musica_Banda_BandaIdBanda",
                        column: x => x.BandaIdBanda,
                        principalTable: "Banda",
                        principalColumn: "IdBanda");
                });

            migrationBuilder.CreateTable(
                name: "ListaFavoritaMusica",
                columns: table => new
                {
                    ListaFavoritasIdListaFavorita = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicasIdMusica = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaFavoritaMusica", x => new { x.ListaFavoritasIdListaFavorita, x.MusicasIdMusica });
                    table.ForeignKey(
                        name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasIdListaFavorita",
                        column: x => x.ListaFavoritasIdListaFavorita,
                        principalTable: "ListaFavorita",
                        principalColumn: "IdListaFavorita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaFavoritaMusica_Musica_MusicasIdMusica",
                        column: x => x.MusicasIdMusica,
                        principalTable: "Musica",
                        principalColumn: "IdMusica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_BandaIdBanda",
                table: "Album",
                column: "BandaIdBanda");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavorita_UsuarioIdUsuario",
                table: "ListaFavorita",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ListaFavoritaMusica_MusicasIdMusica",
                table: "ListaFavoritaMusica",
                column: "MusicasIdMusica");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_AlbumIdAlbum",
                table: "Musica",
                column: "AlbumIdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_BandaIdBanda",
                table: "Musica",
                column: "BandaIdBanda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaFavoritaMusica");

            migrationBuilder.DropTable(
                name: "Plano");

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
