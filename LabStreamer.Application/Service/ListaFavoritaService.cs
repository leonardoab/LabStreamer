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
        private UsuarioRepository UsuarioRepository { get; set; }


        public ListaFavoritaService(IMapper mapper, ListaFavoritaRepository listaFavoritaRepository, MusicaRepository musicaRepository, UsuarioRepository usuarioRepository)
        {
            Mapper = mapper;
            ListaFavoritaRepository = listaFavoritaRepository;
            MusicaRepository = musicaRepository;
            UsuarioRepository = usuarioRepository;
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

            ListaFavorita.Id = id;

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


        public List<ListaFavoritaDto> BuscarListaFavoritaUsuario(Guid id) {


            List<ListaFavorita> listasFavoritas = UsuarioRepository.GetById(id).ListaFavoritas.ToList();

            List<ListaFavoritaDto> listasFavoritsDto = new List<ListaFavoritaDto>();

            foreach (var item in listasFavoritas)
            {
                listasFavoritsDto.Add(Mapper.Map<ListaFavoritaDto>(item));
            }


            return listasFavoritsDto;


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

        public ListaFavorita DesassociarMusicaListaFavorita(Guid idMusica, Guid idListaFavorita)
        {


            ListaFavorita listaFavorita = ListaFavoritaRepository.GetById(idListaFavorita);

            Musica musica = MusicaRepository.GetById(idMusica);

            if (listaFavorita.Musicas is null)
            {
                listaFavorita.Musicas = new List<Musica>();
            }

            listaFavorita.Musicas.Remove(musica);

            ListaFavoritaRepository.Update(listaFavorita);

            return listaFavorita;


        }


    }
}
