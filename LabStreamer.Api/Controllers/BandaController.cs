﻿using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {


        private BandaService _bandaService;

        public BandaController(BandaService bandaService)
        {
            _bandaService = bandaService;
        }


        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(BandaDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.Criar(dto);

            return Ok();

        }

        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar(BandaDto dto, Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.Editar(dto,id);

            return Ok();

        }

        [HttpDelete]
        [Route("Deletar")]
        public IActionResult Deletar(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.Deletar(id);

            return Ok();

        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.BuscarPorParteNome(partenome);

            return Ok(result);

        }


        [HttpPost]
        [Route("AssociarBandaAlbum")]
        public IActionResult AssociarBandaAlbum(Guid idBanda, Guid idAlbum)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.AssociarBandaAlbum(idBanda, idAlbum);

            return Ok();

        }

        [HttpPost]
        [Route("AssociarBandaMusica")]
        public IActionResult AssociarMusicaBanda(Guid idMusica, Guid idBanda)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._bandaService.AssociarMusicaBanda(idMusica, idBanda);

            return Ok();

        }




    }
}
