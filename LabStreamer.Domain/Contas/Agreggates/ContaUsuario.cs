using LabStreamer.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Conta.Agreggates
{
    public class ContaUsuario
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Decimal ValorDisponivel { get; set; }

        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();

    }
}
