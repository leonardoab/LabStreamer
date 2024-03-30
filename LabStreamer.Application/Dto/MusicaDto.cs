using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Dto
{
    public class MusicaDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Duracao { get; set; }
    }

    public class MusicaCompletaDto
    {

        public Guid idMusica { get; set; }

        public string NomeMusica { get; set; }

        public string DuracaoMusica { get; set; }

        public Guid idAbum { get; set; }

        public string NomeAlbum { get; set; }

        public Guid idBanda { get; set; }

        public string NomeBanda { get; set; }

        public bool EstaFavorito { get; set; }


    }


}
