using LabStreamer.Application.Dto;
using LabStreamer.Application.Service;
using LabStreamer.Domain.Conta.Agreggates;
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
        public IActionResult Criar(UsuarioDto dto) { 

        if (ModelState is  { IsValid:false }) return BadRequest();

        var result = this._usuarioService.Criar(dto);

        return Ok(result);
        
        }
    }
}
