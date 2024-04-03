using LabStreamer.Application.Dto;
using LabStreamer.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>().AfterMap((s, d) =>
            {

                d.Senha = "xxxxxxxxx";

            });

            CreateMap<UsuarioLoginDto, Usuario>();
            CreateMap<Usuario, UsuarioLoginDto>().AfterMap((s, d) =>
            {

                d.Senha = "xxxxxxxxx";

            }); ;


        }

    }
}
