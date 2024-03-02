using LabStreamer.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Repository
{
    public class UsuarioRepository: RepositoryBase<Usuario>
    {

        public LabStreamerContext Context { get; set; }


        public UsuarioRepository(LabStreamerContext context) : base (context)
        {
            Context = context;
        }
             
       

    }
}
