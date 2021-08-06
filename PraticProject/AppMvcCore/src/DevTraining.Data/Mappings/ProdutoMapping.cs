using DevTraining.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTraining.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("t_produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .HasColumnName("nome");

            builder.Property(x => x.Descricao)
               .IsRequired()
               .HasColumnType("varchar(1000)")
               .HasColumnName("descricao");

            builder.Property(x => x.Imagem)
               .IsRequired()
               .HasColumnType("varchar(100)")
               .HasColumnName("imagem");

            builder.Property(x => x.Valor)
              .HasColumnType("decimal(5,2)")
              .HasColumnName("valor");

            builder.Property(x => x.Ativo)
              .HasColumnName("ativo");
        }
    }
}
