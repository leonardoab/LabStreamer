using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Repository
{
    public class AlbumRepository : RepositoryBase<Album>
    {

        public LabStreamerContext Context { get; set; }


        public AlbumRepository(LabStreamerContext context) : base(context)
        {
            Context = context;
        }



    }
}
