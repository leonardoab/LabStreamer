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

    public class BandaService
    {
        private IMapper Mapper { get; set; }
        private BandaRepository BandaRepository { get; set; }
        private AlbumRepository AlbumRepository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }


        public BandaService(IMapper mapper, BandaRepository bandaRepository, AlbumRepository albumRepository, MusicaRepository musicaRepository)
        {
            Mapper = mapper;
            BandaRepository = bandaRepository;
            AlbumRepository = albumRepository;
            MusicaRepository = musicaRepository;
        }

        public BandaDto Criar(BandaDto dto)
        {
            Banda Banda = new Banda();

            BandaRepository.Save(Mapper.Map<Banda>(dto));

            var result = Mapper.Map<BandaDto>(Banda);

            return result;

        }

        public BandaDto Editar(BandaDto dto, Guid id)
        {
            Banda Banda = Mapper.Map<Banda>(dto);

            Banda.Id = id;

            BandaRepository.Update(Banda);

            var result = Mapper.Map<BandaDto>(Banda);

            return result;

        }

        public bool Deletar(Guid id)
        {
            Banda Banda = BandaRepository.GetById(id);

            BandaRepository.Delete(Banda);


            return true;

        }

        public BandaDto BuscarPorId(Guid id)
        {
            Banda Banda = BandaRepository.GetById(id);

            var result = Mapper.Map<BandaDto>(Banda);

            return result;

        }

        public List<Banda> BuscarPorParteNome(string partenome)
        {
            var listaAlbuns = BandaRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<Banda>)listaAlbuns;

        }

        public Banda AssociarBandaAlbum(Guid idBanda, Guid idAlbum)
        {


            Album album = AlbumRepository.GetById(idAlbum);

            Banda banda = BandaRepository.GetById(idBanda);

            if (banda.Albuns is null)
            {
                banda.Albuns = new List<Album>();
            }

            banda.Albuns.Add(album);

            BandaRepository.Update(banda);

            return banda;


        }


        public Banda AssociarMusicaBanda(Guid idMusica, Guid idBanda)
        {


            Banda banda = BandaRepository.GetById(idBanda);

            Musica musica = MusicaRepository.GetById(idMusica);

            if (banda.Musicas is null)
            {
                banda.Musicas = new List<Musica>();
            }

            banda.Musicas.Add(musica);

            BandaRepository.Update(banda);

            return banda;


        }


        public List<Banda> BuscarTodasBandas ()
        {

            List<Banda>  todasBandas = (List<Banda>)BandaRepository.GetAll();

            return todasBandas;
        }
    }

}
