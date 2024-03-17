using LabStreamer.Domain.Streamer.Agreggates;
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

        public void CriarUsuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = CriptografarSenha(senha);


        }

        public List<ListaFavorita> ListaFavoritas { get; set; } = new List<ListaFavorita>();

        private String CriptografarSenha(string senha)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senha);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }

    }

   
}
