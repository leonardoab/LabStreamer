using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using LabStreamer.Domain.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private AlbumService _albumService;

        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(AlbumDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._albumService.Criar(dto);

            return Ok();

        }

        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(AlbumDto dto, Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._albumService.Editar(dto,id);

            return Ok();

        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Deletar(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            bool result = this._albumService.Deletar(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._albumService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._albumService.BuscarPorParteNome(partenome);

            return Ok(result);

        }

        [HttpPost]
        [Route("AssociarMusicaAlbum")]
        public IActionResult AssociarMusicaAlbum(Guid idMusica, Guid idAlbum)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._albumService.AssociarMusicaAlbum(idMusica, idAlbum);

            return Ok();

        }


    }
}
