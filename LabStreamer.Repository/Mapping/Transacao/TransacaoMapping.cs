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
    public class TransacaoMapping : IEntityTypeConfiguration<TransacaoUsuario>
    {
        public void Configure(EntityTypeBuilder<TransacaoUsuario> builder)
        {
            builder.ToTable(nameof(Conta));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Autorizada).IsRequired();


        }
    }

   
}
