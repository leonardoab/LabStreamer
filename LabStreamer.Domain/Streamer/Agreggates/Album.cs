using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Streamer.Agreggates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<Musica> Musicas { get; set; } = new List<Musica>();

        public void AdicionarMusica(Musica musica) =>
            this.Musicas.Add(musica);
        public void AdicionarMusica(List<Musica> musica) =>
            this.Musicas.AddRange(musica);
    }
}
