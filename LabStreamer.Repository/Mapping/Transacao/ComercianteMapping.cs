using LabStreamer.Domain.Transacao.Agreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Mapping.Transacao
{

    public class ComercianteMapping : IEntityTypeConfiguration<Comerciante>
    {
        public void Configure(EntityTypeBuilder<Comerciante> builder)
        {
            builder.ToTable(nameof(Conta));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
           

        }
    }


   
}
