using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabStreamer.Domain.Conta.Agreggates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LabStreamer.Repository.Mapping.Conta
{
  

    public class ContaMapping : IEntityTypeConfiguration<ContaUsuario>
    {
        public void Configure(EntityTypeBuilder<ContaUsuario> builder)
        {
            builder.ToTable(nameof(Conta));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.ValorDisponivel).IsRequired();

            builder.HasMany(x => x.Cartoes).WithOne();

            //        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();*/

        }
    }

   


}
