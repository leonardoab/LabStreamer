using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Domains
{
    public class ListaFavorita
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public virtual IList<Musica> Musicas { get; set; } = new List<Musica>();

    }
}
