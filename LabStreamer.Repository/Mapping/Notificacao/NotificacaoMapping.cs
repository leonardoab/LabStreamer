using LabStreamer.Domain.Notificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStreamer.Repository.Mapping.Notificacao
{
   

    public class NotificacaoMapping : IEntityTypeConfiguration<NotificacaoUsuario>
    {
        public void Configure(EntityTypeBuilder<NotificacaoUsuario> builder)
        {
            builder.ToTable(nameof(Conta));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtNotificacao).IsRequired();
            builder.Property(x => x.Mensagem).IsRequired();
            builder.Property(x => x.Titulo).IsRequired();
            





        }
    }


}
