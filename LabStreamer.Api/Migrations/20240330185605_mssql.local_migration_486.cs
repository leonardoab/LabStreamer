using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabStreamer.Api.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_486 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Banda_BandaIdBanda",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioIdUsuario",
                table: "ListaFavorita");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasIdListaFavorita",
                table: "ListaFavoritaMusica");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritaMusica_Musica_MusicasIdMusica",
                table: "ListaFavoritaMusica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Album_AlbumIdAlbum",
                table: "Musica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Banda_BandaIdBanda",
                table: "Musica");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPlano",
                table: "Plano",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BandaIdBanda",
                table: "Musica",
                newName: "BandaId");

            migrationBuilder.RenameColumn(
                name: "AlbumIdAlbum",
                table: "Musica",
                newName: "AlbumId");

            migrationBuilder.RenameColumn(
                name: "IdMusica",
                table: "Musica",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Musica_BandaIdBanda",
                table: "Musica",
                newName: "IX_Musica_BandaId");

            migrationBuilder.RenameIndex(
                name: "IX_Musica_AlbumIdAlbum",
                table: "Musica",
                newName: "IX_Musica_AlbumId");

            migrationBuilder.RenameColumn(
                name: "MusicasIdMusica",
                table: "ListaFavoritaMusica",
                newName: "MusicasId");

            migrationBuilder.RenameColumn(
                name: "ListaFavoritasIdListaFavorita",
                table: "ListaFavoritaMusica",
                newName: "ListaFavoritasId");

            migrationBuilder.RenameIndex(
                name: "IX_ListaFavoritaMusica_MusicasIdMusica",
                table: "ListaFavoritaMusica",
                newName: "IX_ListaFavoritaMusica_MusicasId");

            migrationBuilder.RenameColumn(
                name: "UsuarioIdUsuario",
                table: "ListaFavorita",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdListaFavorita",
                table: "ListaFavorita",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ListaFavorita_UsuarioIdUsuario",
                table: "ListaFavorita",
                newName: "IX_ListaFavorita_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdBanda",
                table: "Banda",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BandaIdBanda",
                table: "Album",
                newName: "BandaId");

            migrationBuilder.RenameColumn(
                name: "IdAlbum",
                table: "Album",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Album_BandaIdBanda",
                table: "Album",
                newName: "IX_Album_BandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Banda_BandaId",
                table: "Album",
                column: "BandaId",
                principalTable: "Banda",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioId",
                table: "ListaFavorita",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasId",
                table: "ListaFavoritaMusica",
                column: "ListaFavoritasId",
                principalTable: "ListaFavorita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritaMusica_Musica_MusicasId",
                table: "ListaFavoritaMusica",
                column: "MusicasId",
                principalTable: "Musica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Album_AlbumId",
                table: "Musica",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Banda_BandaId",
                table: "Musica",
                column: "BandaId",
                principalTable: "Banda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Banda_BandaId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioId",
                table: "ListaFavorita");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasId",
                table: "ListaFavoritaMusica");

            migrationBuilder.DropForeignKey(
                name: "FK_ListaFavoritaMusica_Musica_MusicasId",
                table: "ListaFavoritaMusica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Album_AlbumId",
                table: "Musica");

            migrationBuilder.DropForeignKey(
                name: "FK_Musica_Banda_BandaId",
                table: "Musica");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuario",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plano",
                newName: "IdPlano");

            migrationBuilder.RenameColumn(
                name: "BandaId",
                table: "Musica",
                newName: "BandaIdBanda");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Musica",
                newName: "AlbumIdAlbum");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Musica",
                newName: "IdMusica");

            migrationBuilder.RenameIndex(
                name: "IX_Musica_BandaId",
                table: "Musica",
                newName: "IX_Musica_BandaIdBanda");

            migrationBuilder.RenameIndex(
                name: "IX_Musica_AlbumId",
                table: "Musica",
                newName: "IX_Musica_AlbumIdAlbum");

            migrationBuilder.RenameColumn(
                name: "MusicasId",
                table: "ListaFavoritaMusica",
                newName: "MusicasIdMusica");

            migrationBuilder.RenameColumn(
                name: "ListaFavoritasId",
                table: "ListaFavoritaMusica",
                newName: "ListaFavoritasIdListaFavorita");

            migrationBuilder.RenameIndex(
                name: "IX_ListaFavoritaMusica_MusicasId",
                table: "ListaFavoritaMusica",
                newName: "IX_ListaFavoritaMusica_MusicasIdMusica");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ListaFavorita",
                newName: "UsuarioIdUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ListaFavorita",
                newName: "IdListaFavorita");

            migrationBuilder.RenameIndex(
                name: "IX_ListaFavorita_UsuarioId",
                table: "ListaFavorita",
                newName: "IX_ListaFavorita_UsuarioIdUsuario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Banda",
                newName: "IdBanda");

            migrationBuilder.RenameColumn(
                name: "BandaId",
                table: "Album",
                newName: "BandaIdBanda");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Album",
                newName: "IdAlbum");

            migrationBuilder.RenameIndex(
                name: "IX_Album_BandaId",
                table: "Album",
                newName: "IX_Album_BandaIdBanda");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Banda_BandaIdBanda",
                table: "Album",
                column: "BandaIdBanda",
                principalTable: "Banda",
                principalColumn: "IdBanda");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavorita_Usuario_UsuarioIdUsuario",
                table: "ListaFavorita",
                column: "UsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritaMusica_ListaFavorita_ListaFavoritasIdListaFavorita",
                table: "ListaFavoritaMusica",
                column: "ListaFavoritasIdListaFavorita",
                principalTable: "ListaFavorita",
                principalColumn: "IdListaFavorita",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaFavoritaMusica_Musica_MusicasIdMusica",
                table: "ListaFavoritaMusica",
                column: "MusicasIdMusica",
                principalTable: "Musica",
                principalColumn: "IdMusica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Album_AlbumIdAlbum",
                table: "Musica",
                column: "AlbumIdAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_Musica_Banda_BandaIdBanda",
                table: "Musica",
                column: "BandaIdBanda",
                principalTable: "Banda",
                principalColumn: "IdBanda");
        }
    }
}
