

using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig
{
   public class CnhConfiguration : EntityTypeConfiguration<Cnh>
    {
        public CnhConfiguration()
        {
            HasKey(c => c.CnhId);

            Property(c => c.NomeDaPessoaCompleto)
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
