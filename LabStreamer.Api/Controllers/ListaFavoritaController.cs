using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaFavoritaController : ControllerBase
    {
        private ListaFavoritaService _listaFavoritaService;

        public ListaFavoritaController(ListaFavoritaService listaFavoritaService)
        {
            _listaFavoritaService = listaFavoritaService;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(ListaFavoritaDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.Criar(dto);

            return Ok(result);

        }

        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(ListaFavoritaDto dto, Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.Editar(dto,id);

            return Ok(result);

        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Deletar(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.Deletar(id);

            return Ok();

        }


        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.BuscarPorParteNome(partenome);

            return Ok(result);

        }

        [HttpPost]
        [Route("AssociarMusicaListaFavorita")]
        public IActionResult AssociarMusicaListaFavorita(Guid idMusica, Guid idListaFavorita)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._listaFavoritaService.AssociarMusicaListaFavorita(idMusica, idListaFavorita);

            return Ok();

        }
    }
}
