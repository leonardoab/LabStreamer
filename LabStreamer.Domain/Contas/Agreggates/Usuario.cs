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

        public Assinatura Assinatura { get; set; }
        public ContaUsuario ContaUsuario { get; set; }
        public List<NotificacaoUsuario> NotificacaoUsuarios { get; set; } = new List<NotificacaoUsuario>();

        public List<ListaReproducao> ListaReproducoes { get; set; } = new List<ListaReproducao>();
        public List<ListaFavorita> ListaFavoritas { get; set; } = new List<ListaFavorita>();


        public void CriarConta(string nome, string email, string senha, DateTime dtNascimento, Plano plano, ContaUsuario contausuario)
        {
            this.Nome = nome;
            this.Email = email;

            ContaUsuario ContaUsuario = new ContaUsuario();

            Assinatura Assinatura = new Assinatura();


            //Criptografar a senha
            this.Senha = this.CriptografarSenha(senha);

            //Assinar um plano
            this.AssinarPlano(plano, ContaUsuario.Cartoes[0]);

            //Adicionar cartão na conta do usuário
            this.AdicionarCartao(ContaUsuario.Cartoes[0]);

            //Criar a playlist padrão do usuario
            this.CriarListaReproducao(nome);




        }

        public void CriarListaReproducao(string nome, bool publica = true)
        {
            this.ListaReproducoes.Add(new ListaReproducao()
            {
                Nome = nome,                
            });
        }

        private void AdicionarCartao(Cartao cartao)
            => this.ContaUsuario.Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Comerciante() { Nome = plano.Nome }, plano.Valor, plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura


            this.Assinatura.Valor = plano.Valor;

            this.Assinatura.Plano = plano;

            this.Assinatura.DataCriacao = DateTime.Now;


            

        }

        private void DesativarAssinaturaAtiva()
        {
            this.Assinatura = null;

          
        }

        private String CriptografarSenha(string senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
