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

    public class PlanoService
    {
        private IMapper Mapper { get; set; }
        private PlanoRepository PlanoRepository { get; set; }
        private AlbumRepository AlbumRepository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }


        public PlanoService(IMapper mapper, AlbumRepository albumRepository, MusicaRepository musicaRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            
            AlbumRepository = albumRepository;
            MusicaRepository = musicaRepository;
            PlanoRepository = planoRepository;
        }

        public PlanoDto Criar(PlanoDto dto)
        {
            Plano Plano = new Plano();

            PlanoRepository.Save(Mapper.Map<Plano>(dto));

            var result = Mapper.Map<PlanoDto>(Plano);

            return result;

        }

        public PlanoDto Editar(PlanoDto dto, Guid id)
        {
            Plano Plano = Mapper.Map<Plano>(dto);

            Plano.Id = id;

            PlanoRepository.Update(Plano);

            var result = Mapper.Map<PlanoDto>(Plano);

            return result;

        }

        public bool Deletar(Guid id)
        {
            Plano Plano = PlanoRepository.GetById(id);

            PlanoRepository.Delete(Plano);


            return true;

        }

        public PlanoDto BuscarPorId(Guid id)
        {
            Plano Plano = PlanoRepository.GetById(id);

            var result = Mapper.Map<PlanoDto>(Plano);

            return result;

        }

        public List<Plano> BuscarPorParteNome(string partenome)
        {
            var listaPlanos = PlanoRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<Plano>)listaPlanos;

        }

        public List<PlanoDto> BuscarTodosPlanos()
        {
            var listaPlanos = PlanoRepository.GetAll();

            List<PlanoDto> listaPlanoDto = new List<PlanoDto>();

            foreach (var item in listaPlanos)
            {

                PlanoDto planoDto = Mapper.Map<PlanoDto>(item);
                listaPlanoDto.Add(planoDto);

            }   

          

            return listaPlanoDto;

        }





    }

}
