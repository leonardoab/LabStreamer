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
    public class MusicaService
    {
        private IMapper Mapper { get; set; }
        private MusicaRepository MusicaRepository { get; set; }


        public MusicaService(IMapper mapper, MusicaRepository musicaRepository)
        {
            Mapper = mapper;
            MusicaRepository = musicaRepository;
        }

        public MusicaDto Criar(MusicaDto dto)
        {
            Musica Musica = new Musica();

            MusicaRepository.Save(Mapper.Map<Musica>(dto));

            var result = Mapper.Map<MusicaDto>(Musica);

            return result;

        }

        public MusicaDto Editar(MusicaDto dto, Guid id)
        {
            Musica Musica = Mapper.Map<Musica>(dto);

            Musica.Id = id;

            MusicaRepository.Update(Musica);

            var result = Mapper.Map<MusicaDto>(Musica);

            return result;

        }

        public bool Deletar(Guid id)
        {
            Musica Musica = MusicaRepository.GetById(id);

            MusicaRepository.Delete(Musica);


            return true;

        }

        public MusicaDto BuscarPorId(Guid id)
        {
            Musica Musica = MusicaRepository.GetById(id);

            var result = Mapper.Map<MusicaDto>(Musica);

            return result;

        }

        public List<Musica> BuscarPorParteNome(string partenome)
        {
            var listaAlbuns = MusicaRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<Musica>)listaAlbuns;

        }




    }
}
