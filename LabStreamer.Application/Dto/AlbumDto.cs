using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Dto
{
    public class AlbumDto
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

       


    }
}
