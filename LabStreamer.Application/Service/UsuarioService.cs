using AutoMapper;
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


        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
        }




        public UsuarioDto Criar(UsuarioDto dto)
        {

            if (UsuarioRepository.Exists(x => x.Email == dto.Email))
            {

                throw new Exception("Usuario já existe");
            }

            Usuario usuario = new Usuario();

            usuario.CriarUsuario(dto.Nome, dto.Email, dto.Senha);

            usuario.DataCriacao = DateTime.Now;

            usuario.Ativo = true;

            UsuarioRepository.Save(usuario);

            var result = Mapper.Map<UsuarioDto>(usuario);

            return result;

        }




    }
}
