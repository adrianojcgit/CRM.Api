using CMR.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infra.Data.EntitiesConfiguration
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CodInterno).HasMaxLength(15).IsRequired();
            builder.Property(x => x.CnpjNumInscricao).HasMaxLength(18).IsRequired();
            builder.Property(x => x.CnpjConsultado).HasMaxLength(14).IsRequired();
            builder.Property(x => x.CnpjParametro).HasMaxLength(14).IsRequired();
            builder.Property(x => x.NomeEmpresarial).HasMaxLength(200).IsRequired();
            builder.Property(x => x.NomeFantasia).HasMaxLength(100).IsRequired();
            
        }       
    }


}
