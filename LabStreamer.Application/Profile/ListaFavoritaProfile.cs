using LabStreamer.Application.Dto;
using LabStreamer.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Profile
{
    public class ListaFavoritaProfile : AutoMapper.Profile
    {
        public ListaFavoritaProfile()
        {
            CreateMap<ListaFavoritaDto, ListaFavorita>();
            CreateMap<ListaFavorita, ListaFavoritaDto>();

        }
    }
   
}
