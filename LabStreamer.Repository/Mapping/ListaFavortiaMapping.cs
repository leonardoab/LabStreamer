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

    public class ListaFavortiaMapping : IEntityTypeConfiguration<ListaFavorita>
    {
        public void Configure(EntityTypeBuilder<ListaFavorita> builder)
        {
            builder.ToTable(nameof(ListaFavorita));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();

            //builder.HasMany(a => a.Musicas).WithOne(); // Especifica o relacionamento de Album para Musicas


            builder.HasMany(x => x.Musicas).WithMany(x => x.ListaFavoritas);

        }
    }



}
