using LabStreamer.Domain.Streamer.Agreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Mapping.Streaming
{


    public class ListaReproducaoMapping : IEntityTypeConfiguration<ListaReproducao>
    {
        public void Configure(EntityTypeBuilder<ListaReproducao> builder)
        {
            builder.ToTable(nameof(Conta));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();

            builder.HasMany(x => x.Musicas).WithMany(x => x.ListaReproducoes);
        }
    }



}
