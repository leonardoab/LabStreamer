using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Domain.Transacao.Agreggates
{
    public class Cartao
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public string Numero { get; set; }
        public string CodigoVerificador { get; set; }
        public Decimal ValorLimite { get; set; }
        public DateTime Validade { get; set; }

        public List<TransacaoUsuario> Transacoes { get; set; } = new List<TransacaoUsuario>();

        public void CriarTransacao(Comerciante comerciante, decimal valor, string Descricao = "")
        {
            //Verificar se o cartão está ativo
            this.IsCartaoAtivo();

            TransacaoUsuario transacao = new TransacaoUsuario();
            transacao.Comerciante = new Comerciante();

            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.DataCriacao = DateTime.Now;

            //Verifica limite disponivel
            this.VerificaLimite(transacao);

            //Verifica regras antifraude
            this.ValidarTransacao(transacao);

            //Cria numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            this.ValorLimite = this.ValorLimite - transacao.Valor;

            this.Transacoes.Add(transacao);

        }

        private void ValidarTransacao(TransacaoUsuario transacao)
        {
            var ultimasTransacoes = this.Transacoes.Where(x =>
                                                          x.DataCriacao >= DateTime.Now.AddMinutes(-2));
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado muitas vezes em um período curto");

            var transacaoRepetidaPorMerchant = ultimasTransacoes?
                                                .Where(x => x.Comerciante.Nome.ToUpper() == transacao.Comerciante.Nome.ToUpper()
                                                       && x.Valor == transacao.Valor)
                                                .Count() == 1;

            if (transacaoRepetidaPorMerchant)
                throw new Exception("Transacao Duplicada para o mesmo cartão e o mesmo Comerciante");

        }

        private void VerificaLimite(TransacaoUsuario transacao)
        {
            if (this.ValorLimite < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transacao");
        }

        private void IsCartaoAtivo()
        {
            if (this.Ativo == false)
                throw new Exception("Cartão não está ativo");
        }
    }
}
