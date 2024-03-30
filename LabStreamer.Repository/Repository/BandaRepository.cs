using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabStreamer.Repository.Repository
{
    public class BandaRepository : RepositoryBase<Banda>
    {

        public LabStreamerContext Context { get; set; }


        public BandaRepository(LabStreamerContext context) : base(context)
        {
            Context = context;
        }


    }
}
