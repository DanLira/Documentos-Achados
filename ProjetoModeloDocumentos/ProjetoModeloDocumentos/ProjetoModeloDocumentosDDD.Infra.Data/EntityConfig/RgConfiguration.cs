
using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig
{
  public class RgConfiguration : EntityTypeConfiguration<Rg>
    {
        public RgConfiguration()
        {
            HasKey(c => c.RgId);

            Property(c => c.NomeDaPessoCompleto)
                .IsRequired()
                .HasMaxLength(150);

            

            Property(c => c.Datanascimento)
                .IsRequired();

            Property(c => c.NomeMae)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.NomePai)
                .IsRequired()
                .HasMaxLength(150);

            HasRequired(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId);


        }
    }
}
