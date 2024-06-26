﻿using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult Criar(UsuarioCadastroDto dto)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            UsuarioDto usuarioDto = new UsuarioDto();

            usuarioDto.Email = dto.Email;
            usuarioDto.Senha = dto.Senha;
            usuarioDto.Nome = dto.Nome;


            var result = this._usuarioService.Criar(usuarioDto, dto.idPlano);

            return Ok(result);

        }

        [HttpPost]
        [Route("Autenticar")]
        public IActionResult Autenticar(UsuarioLoginDto dto)
        {
            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._usuarioService.Autenticar(dto.Email,dto.Senha);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        [Route("BuscarPorId")]
        public IActionResult BuscarPorId(Guid id)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._usuarioService.BuscarPorId(id);

            return Ok(result);

        }

        [HttpGet]
        [Route("BuscarPorParteNome")]
        public IActionResult BuscarPorParteNome(string partenome)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._usuarioService.BuscarPorParteNome(partenome);

            return Ok(result);

        }

        [HttpPost]
        [Route("AssociarUsuarioListaFavorita")]
        public IActionResult AssociarUsuarioListaFavorita(Guid idUsuario, Guid idListaFavorita)
        {

            if (ModelState is { IsValid: false }) return BadRequest();

            var result = this._usuarioService.AssociarUsuarioListaFavorita(idUsuario, idListaFavorita);

            return Ok();

        }

    }
}
