using DevTraining.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTraining.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("t_fornecedor");
            builder.HasKey(f => f.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("nome");

            builder.Property(f => f.Documento)
               .IsRequired()
               .HasColumnType("varchar(14)")
               .HasColumnName("documento");

            builder.Property(f => f.Ativo)
               .HasColumnName("ativo");

            // 1:1 fornecedor : endereço
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            //1:N => fornecedor : produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);


        }
    }
}
