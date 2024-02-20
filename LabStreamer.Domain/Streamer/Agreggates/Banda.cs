using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Streamer.Agreggates
{
    public class Banda
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Album> Albuns { get; set; }
        public List<Musica> Musicas { get; set; }



        //public void AdicionarAlbum(Album album) => this.Albuns.Add(album);
    }
}
