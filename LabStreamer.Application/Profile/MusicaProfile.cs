using LabStreamer.Application.Dto;
using LabStreamer.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Profile
{
    public class MusicaProfile : AutoMapper.Profile
    {
        public MusicaProfile()
        {
            CreateMap<MusicaDto, Musica>();
            CreateMap<Musica, MusicaDto>();

        }
    }
}
