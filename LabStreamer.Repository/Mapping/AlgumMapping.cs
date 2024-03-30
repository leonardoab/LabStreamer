using LabStreamer.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Mapping
{


    public class AlgumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable(nameof(Album));

            builder.HasKey(x => x.IdAlbum);
            builder.Property(x => x.IdAlbum).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();

            builder.HasMany(a => a.Musicas).WithOne(); // Especifica o relacionamento de Album para Musicas


        }
    }
}
