using DevTraining.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevTraining.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("t_endereco");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasColumnName("estado");

            builder.Property(e => e.Cidade)
               .IsRequired()
               .HasColumnType("varchar(100)")
               .HasColumnName("cidade");

            builder.Property(e => e.Logradouro)
               .IsRequired()
               .HasColumnType("varchar(200)")
               .HasColumnName("logradouro");

            builder.Property(e => e.Complemento)
               .IsRequired()
               .HasColumnType("varchar(250)")
               .HasColumnName("complemento");

            builder.Property(e => e.Cep)
               .IsRequired()
               .HasColumnType("varchar(8)")
               .HasColumnName("cep");

            builder.Property(e => e.Bairro)
               .IsRequired()
               .HasColumnType("varchar(200)")
               .HasColumnName("bairro");

            builder.Property(e => e.Numero)
               .IsRequired()
               .HasColumnType("varchar(50)")
               .HasColumnName("numero");

        }
    }
}
