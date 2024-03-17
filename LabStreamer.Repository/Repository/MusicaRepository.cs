using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {

        public LabStreamerContext Context { get; set; }


        public MusicaRepository(LabStreamerContext context) : base(context)
        {
            Context = context;
        }



    }
}
