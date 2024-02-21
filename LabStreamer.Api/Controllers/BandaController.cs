using LabStreamer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabStreamer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandaController : ControllerBase
    {
        public LabStreamerContext Context { get; set; }

        public BandaController(LabStreamerContext context)
        {

            Context = context;

        }





        [HttpGet("{id}")]
        public IActionResult GetBandasFiltradas(Guid id)
        {

            var result = this.Context.Bandas.Where(x => x.Id == id).ToList();


            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);


        }

       


    }
}
