﻿using AutoMapper;
using LabStreamer.Application.Dto;
using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Service
{
    public class UsuarioService
    {
        private IMapper Mapper { get; set; }
        private UsuarioRepository UsuarioRepository { get; set; }
        private ListaFavoritaRepository ListaFavoritaRepository { get; set; }
        private PlanoRepository PlanoRepository { get; set; }


        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, ListaFavoritaRepository listaFavoritaRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            ListaFavoritaRepository = listaFavoritaRepository;
            PlanoRepository = planoRepository;
        }


        public UsuarioDto Criar(UsuarioDto dto, Guid idPlano)
        {

            if (UsuarioRepository.Exists(x => x.Email == dto.Email))
            {

                throw new Exception("Usuario já existe");
            }

            Usuario usuario = new Usuario();

            usuario.CriarUsuario(dto.Nome, dto.Email, dto.Senha);

            usuario.DataCriacao = DateTime.Now;

            usuario.Ativo = true;

            Plano plano = PlanoRepository.GetById(idPlano);

            usuario.Plano = plano;

            usuario.PlanoId = plano.Id;            

            ListaFavorita listaFavorita = new ListaFavorita();

            listaFavorita.Nome = "Musicas Favoritas";

            ListaFavoritaRepository.Save(listaFavorita);

            usuario.ListaFavoritas.Add(listaFavorita);

            UsuarioRepository.Save(usuario);

            var result = Mapper.Map<UsuarioDto>(usuario);

            return result;

        }


        public UsuarioDto Editar(UsuarioDto dto, Guid id)
        {
            Usuario Usuario = Mapper.Map<Usuario>(dto);

            Usuario.Id = id;

            UsuarioRepository.Update(Usuario);

            var result = Mapper.Map<UsuarioDto>(Usuario);

            return result;

        }

        public bool Deletar(Guid id)
        {
            Usuario Usuario = UsuarioRepository.GetById(id);

            UsuarioRepository.Delete(Usuario);


            return true;

        }

        public UsuarioDto BuscarPorId(Guid id)
        {
            Usuario Usuario = UsuarioRepository.GetById(id);

            var result = Mapper.Map<UsuarioDto>(Usuario);

            return result;

        }

        public List<Usuario> BuscarPorParteNome(string partenome)
        {
            var listaAlbuns = UsuarioRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<Usuario>)listaAlbuns;

        }

        public Usuario AssociarUsuarioListaFavorita(Guid idUsuario, Guid idListaFavorita)
        {


            ListaFavorita listaFavorita = ListaFavoritaRepository.GetById(idListaFavorita);

            Usuario usuario = UsuarioRepository.GetById(idUsuario);

            if (usuario.ListaFavoritas is null)
            {
                usuario.ListaFavoritas = new List<ListaFavorita>();
            }

            usuario.ListaFavoritas.Add(listaFavorita);

            UsuarioRepository.Update(usuario);

            return usuario;


        }

        public UsuarioDto Autenticar(string email, string senha)
        {
            //UsuarioLoginDto result;

            var usuarioRetorno = UsuarioRepository.Find(x => x.Email.Contains(email)).FirstOrDefault();

            if (usuarioRetorno.CriptografarSenha(senha) != usuarioRetorno.Senha) { return null; }

            else
            {
                var result = Mapper.Map<UsuarioDto>(usuarioRetorno);

                return result;
            }

        }




    }
}
