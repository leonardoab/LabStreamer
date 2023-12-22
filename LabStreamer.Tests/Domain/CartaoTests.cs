using LabStreamer.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Tests.Domain
{
    public class CartaoTests
    {

        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorLimite = 1000M,
                Numero = "6465465466",
            };

            Comerciante comerciante = new Comerciante()
            {
                Id = Guid.NewGuid(),
                Nome = "Joao"
            };

           

            cartao.CriarTransacao(comerciante, 19M, "Joao Transacao");
            Assert.True(cartao.Transacoes.Count > 0);
            Assert.True(cartao.ValorLimite == 981M);

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                ValorLimite = 1000M,
                Numero = "6465465466",
            };

            Comerciante comerciante = new Comerciante()
            {
                Id = Guid.NewGuid(),
                Nome = "Joao"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "Joao Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoSemLimite()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorLimite = 10M,
                Numero = "6465465466",
            };

            Comerciante comerciante = new Comerciante()
            {
                Id = Guid.NewGuid(),
                Nome = "Joao"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "Joao Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoValorDuplicado()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorLimite = 1000M,
                Numero = "6465465466",
            };

            cartao.Transacoes.Add(new TransacaoUsuario()
            {
                DataCriacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Comerciante = new Comerciante()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Joao"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            Comerciante comerciante = new Comerciante()
            {
                Id = Guid.NewGuid(),
                Nome = "Joao"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "Joao Transacao"));

        }

        
    }
}
