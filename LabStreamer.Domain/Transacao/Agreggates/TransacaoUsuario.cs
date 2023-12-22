using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Transacao.Agreggates
{
    public class TransacaoUsuario
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public Decimal Valor { get; set; }
        public string Descricao { get; set; }
        public Boolean Autorizada { get; set; }

        public Comerciante Comerciante { get; set; }    
    }
}
