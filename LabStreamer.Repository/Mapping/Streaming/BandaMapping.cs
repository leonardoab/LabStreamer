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
    public class BandaMapping : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable(nameof(Banda));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();

            //builder.HasOne(x => x.Albuns).WithMany();
            builder.HasMany<Album>(x => x.Albuns).WithOne();
            builder.HasMany<Musica>(x => x.Musicas).WithOne();


        }
    }

   
}
