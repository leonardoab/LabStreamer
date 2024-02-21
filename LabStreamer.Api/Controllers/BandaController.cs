using LabStreamer.Domain.Streamer.Agreggates;
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


            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);


        }

        [HttpPost]
        public IActionResult SaveBandas([FromBody] Banda banda)
        {

            this.Context.Bandas.Add(banda);
            this.Context.SaveChanges();
            return Created($"/banda/{banda.Id}", banda);



        }




    }
}
