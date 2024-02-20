using SpotifyLike.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Streamer.Agreggates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        //public Duracao Duracao { get; set; }
        //
        public List<ListaFavorita> ListaFavoritas { get; set; }

    }
}
