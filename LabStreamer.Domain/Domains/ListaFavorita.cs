using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Domains
{
    public class ListaFavorita
    {
        public Guid IdListaFavorita { get; set; }
        public string Nome { get; set; }

        public List<Musica> Musicas { get; set; }

    }
}
