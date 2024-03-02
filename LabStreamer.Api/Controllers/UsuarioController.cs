using LabStreamer.Application.Contas.Request;
using LabStreamer.Domain.Conta.Agreggates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IActionResult Criar(UsuarioDto dto) { 

        if (ModelState is  { IsValid:false }) return BadRequest();

        return Ok();
        
        }
    }
}
