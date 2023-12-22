using LabStreamer.Domain.Conta.Agreggates;
using LabStreamer.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Tests.Domain
{
    public class UsuarioTest
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Nome = "Plano Dummy",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorLimite = 1000M,
                Numero = "6465465466",
            };

            ContaUsuario contaUsuario = new ContaUsuario()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorDisponivel = 1000M,
                Cartoes.add(cartao)
            };

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";

            //Act
            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, DateTime.Now, plano, contaUsuario);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Senha != senha);



            Assert.True(usuario.ContaUsuario.Cartoes.Count > 0);
            Assert.Same(usuario.ContaUsuario.Cartoes[0], cartao);

            Assert.True(usuario.ListaReproducoes.Count > 0);
            Assert.True(usuario.ListaReproducoes[0].Nome == "Favoritas");
           
        }

        [Fact]
        public void NaoDeveCriarUsuarioComCartaoSemLimite()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Nome = "Plano Dummy",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                ValorLimite = 10M,
                Numero = "6465465466",
            };

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string senha = "123456";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, DateTime.Now, plano, contausuario);
            });
        }
    }
}
