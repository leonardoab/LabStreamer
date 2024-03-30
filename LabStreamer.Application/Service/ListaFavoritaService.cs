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
    public class ListaFavoritaService
    {
        private IMapper Mapper { get; set; }
        private ListaFavoritaRepository ListaFavoritaRepository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }


        public ListaFavoritaService(IMapper mapper, ListaFavoritaRepository listaFavoritaRepository, MusicaRepository musicaRepository)
        {
            Mapper = mapper;
            ListaFavoritaRepository = listaFavoritaRepository;
            MusicaRepository = musicaRepository;
        }

        public ListaFavoritaDto Criar(ListaFavoritaDto dto)
        {
            ListaFavorita ListaFavorita = new ListaFavorita();

            ListaFavoritaRepository.Save(Mapper.Map<ListaFavorita>(dto));

            var result = Mapper.Map<ListaFavoritaDto>(ListaFavorita);

            return result;

        }

        public ListaFavoritaDto Editar(ListaFavoritaDto dto, Guid id)
        {
            ListaFavorita ListaFavorita = Mapper.Map<ListaFavorita>(dto);

            ListaFavorita.IdListaFavorita = id;

            ListaFavoritaRepository.Update(ListaFavorita);

            var result = Mapper.Map<ListaFavoritaDto>(ListaFavorita);

            return result;

        }

        public bool Deletar(Guid id)
        {
            ListaFavorita ListaFavorita = ListaFavoritaRepository.GetById(id);

            ListaFavoritaRepository.Delete(ListaFavorita);


            return true;

        }

        public ListaFavoritaDto BuscarPorId(Guid id)
        {
            ListaFavorita ListaFavorita = ListaFavoritaRepository.GetById(id);

            var result = Mapper.Map<ListaFavoritaDto>(ListaFavorita);

            return result;

        }

        public List<ListaFavorita> BuscarPorParteNome(string partenome)
        {
            var listaAlbuns = ListaFavoritaRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<ListaFavorita>)listaAlbuns;

        }



        public ListaFavorita AssociarMusicaListaFavorita(Guid idMusica, Guid idListaFavorita)
        {


            ListaFavorita listaFavorita = ListaFavoritaRepository.GetById(idListaFavorita);

            Musica musica = MusicaRepository.GetById(idMusica);

            if (listaFavorita.Musicas is null)
            {
                listaFavorita.Musicas = new List<Musica>();
            }

            listaFavorita.Musicas.Add(musica);

            ListaFavoritaRepository.Update(listaFavorita);

            return listaFavorita;


        }


    }
}
