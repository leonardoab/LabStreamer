using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private MusicaService _musicaService;

        public MusicaController(MusicaService musicaService)
        {
            _musicaService = musicaService;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(MusicaDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.Criar(dto);

            return Ok();

        }

        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(MusicaDto dto, Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.Editar(dto,id);

            return Ok();

        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Deletar(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.Deletar(id);

            return Ok();

        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.BuscarPorParteNome(partenome);

            return Ok(result);

        }


        [HttpGet]
        [Route("BuscaMusicasCompleto")]
        public IActionResult BuscaMusicasCompleto()
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._musicaService.BuscarTodasMusicas();

            return Ok(result);

        }



    }
}
