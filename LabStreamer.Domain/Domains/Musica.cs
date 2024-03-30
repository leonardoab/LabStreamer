
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
        public string Duracao { get; set; }
        //
        public virtual IList<ListaFavorita> ListaFavoritas { get; set; } = new List<ListaFavorita>();

    }
}
