using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {


        private PlanoService _PlanoService;

        public PlanoController(PlanoService PlanoService)
        {
            _PlanoService = PlanoService;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(PlanoDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._PlanoService.Criar(dto);

            return Ok();

        }

        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(PlanoDto dto, Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._PlanoService.Editar(dto,id);

            return Ok();

        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Deletar(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._PlanoService.Deletar(id);

            return Ok();

        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._PlanoService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._PlanoService.BuscarPorParteNome(partenome);

            return Ok(result);

        }


        




    }
}
