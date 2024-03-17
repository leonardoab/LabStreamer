using LabStreamer.Application.Dto;
using LabStreamer.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Profile
{
    public class BandaProfile : AutoMapper.Profile
    {
        public BandaProfile()
        {
            CreateMap<BandaDto, Banda>();
            CreateMap<Banda, BandaDto>();

        }
    }
    
}
