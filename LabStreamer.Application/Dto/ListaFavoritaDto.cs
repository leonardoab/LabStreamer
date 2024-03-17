using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Dto
{
    public class ListaFavoritaDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
