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
    public class AlbumService
    {
        private IMapper Mapper { get; set; }
        private AlbumRepository AlbumRepository { get; set; }
        private MusicaRepository MusicaRepository { get; set; }


        public AlbumService(IMapper mapper, AlbumRepository albumRepository, MusicaRepository musicaRepository)
        {
            Mapper = mapper;
            AlbumRepository = albumRepository;
            MusicaRepository = musicaRepository;
        }


        public AlbumDto Criar(AlbumDto dto)
        {
            Album album = new Album();

            AlbumRepository.Save(Mapper.Map<Album>(dto));

            var result = Mapper.Map<AlbumDto>(album);

            return result;

        }

        public AlbumDto Editar(AlbumDto dto, Guid id)
        {
            Album album = Mapper.Map<Album>(dto);

            album.Id = id;

            AlbumRepository.Update(album);

            var result = Mapper.Map<AlbumDto>(album);

            return result;

        }

        public bool Deletar(Guid id)
        {
            Album album = AlbumRepository.GetById(id);

            AlbumRepository.Delete(album);


            return true;

        }

        public AlbumDto BuscarPorId(Guid id)
        {
            Album album = AlbumRepository.GetById(id);

            var result = Mapper.Map<AlbumDto>(album);

            return result;

        }

        public List<Album> BuscarPorParteNome(string partenome)
        {
            var listaAlbuns = AlbumRepository.Find(x => x.Nome.Contains(partenome)).ToList();

            return (List<Album>)listaAlbuns;

        }

        public Album AssociarMusicaAlbum(Guid idMusica, Guid idAlbum)
        {


            Album album = AlbumRepository.GetById(idAlbum);

            Musica musica = MusicaRepository.GetById(idMusica);

            if (album.Musicas is null)
            {
                album.Musicas = new List<Musica>();
            }

            album.Musicas.Add(musica);

            AlbumRepository.Update(album);

            return album;


        }

        


    }
}
