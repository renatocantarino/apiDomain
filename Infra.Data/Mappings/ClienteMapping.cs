using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity.ToTable("Clientes");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome);
            entity.Property(e => e.SobreNome);
            entity.Property(e => e.Email);
        }
    }
}