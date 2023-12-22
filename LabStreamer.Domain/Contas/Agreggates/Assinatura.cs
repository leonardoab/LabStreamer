using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Conta.Agreggates
{
    public class Assinatura
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public Decimal Valor { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataCriacao { get; set; }     

        public Plano Plano { get; set; }
    }
}
