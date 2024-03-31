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
        private BandaRepository BandaRepository { get; set; }
        private ListaFavoritaRepository ListaFavoritaRepository { get; set; }


        public MusicaService(IMapper mapper, MusicaRepository musicaRepository, BandaRepository bandaRepository, ListaFavoritaRepository listaFavoritaRepository)
        {
            Mapper = mapper;
            MusicaRepository = musicaRepository;
            BandaRepository = bandaRepository;
            ListaFavoritaRepository = listaFavoritaRepository;
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

        public List<MusicaCompletaDto> BuscarTodasMusicas(Guid id = default)
        {
            IEnumerable<Banda> todasBandas = BandaRepository.GetAll();

            ListaFavorita listaFavorita = new ListaFavorita();

            if (id == default)
            {
                // Lógica para buscar todas as músicas quando o id não for especificado
            }
            else
            {
                listaFavorita = ListaFavoritaRepository.GetById(id);
            }

            

            List<MusicaCompletaDto> listaMusicaCompleta = new List<MusicaCompletaDto>();

            foreach (var itemBanda in todasBandas)
            {
                foreach (var itemAlbum in itemBanda.Albuns)
                {
                    foreach (var itemMusica in itemAlbum.Musicas)
                    {
                        MusicaCompletaDto MusicaCompletaDto = new MusicaCompletaDto();

                        MusicaCompletaDto.idMusica = itemMusica.Id;
                        MusicaCompletaDto.DuracaoMusica = itemMusica.Duracao;
                        MusicaCompletaDto.NomeMusica = itemMusica.Nome;
                        MusicaCompletaDto.idAbum = itemAlbum.Id;
                        MusicaCompletaDto.NomeAlbum = itemAlbum.Nome;
                        MusicaCompletaDto.idBanda = itemBanda.Id;
                        MusicaCompletaDto.NomeBanda = itemBanda.Nome;                        

                        MusicaCompletaDto.EstaFavorito = listaFavorita.Musicas.Contains(itemMusica); 

                        listaMusicaCompleta.Add(MusicaCompletaDto);



                    }
                }

            }

            return listaMusicaCompleta;
        }




    }
}
