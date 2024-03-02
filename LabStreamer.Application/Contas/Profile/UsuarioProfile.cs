using LabStreamer.Application.Contas.Request;
using LabStreamer.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Contas.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        protected UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
