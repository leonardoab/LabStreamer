using LabStreamer.Domain.Notificacao;
using LabStreamer.Domain.Streamer.Agreggates;
using LabStreamer.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Conta.Agreggates
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Boolean Ativo { get; set; }        
        public DateTime DataCriacao { get; set; }

        public List<ListaFavorita> ListaFavoritas { get; set; } = new List<ListaFavorita>();
                
    }
}
