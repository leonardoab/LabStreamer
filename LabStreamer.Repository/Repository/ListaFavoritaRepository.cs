using LabStreamer.Domain.Domains;
using LabStreamer.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Repository
{
    public class ListaFavoritaRepository : RepositoryBase<ListaFavorita>
    {

        public LabStreamerContext Context { get; set; }


        public ListaFavoritaRepository(LabStreamerContext context) : base(context)
        {
            Context = context;
        }



    }
}
