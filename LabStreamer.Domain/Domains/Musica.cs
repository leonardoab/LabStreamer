
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Domains
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //public Duracao Duracao { get; set; }
        //
        public List<ListaFavorita> ListaFavoritas { get; set; }

    }
}
