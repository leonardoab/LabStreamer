using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Application.Dto
{
    public class UsuarioDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public Guid Id { get; set; }

    }

    public class UsuarioLoginDto
    {
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }

    public class UsuarioCadastroDto
    {
        public Guid idPlano { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

    }

}
