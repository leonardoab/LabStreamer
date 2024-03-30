using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Domains
{
    public class Plano
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
