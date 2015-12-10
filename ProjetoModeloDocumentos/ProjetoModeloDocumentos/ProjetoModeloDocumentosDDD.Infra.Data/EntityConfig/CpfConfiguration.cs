

using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig
{
   public class CpfConfiguration : EntityTypeConfiguration<Cpf>
    {
        public CpfConfiguration()
        {
            HasKey(c => c.CpfId);

            Property(c => c.NomeDaPessoaCompleto)
                .IsRequired()
                .HasMaxLength(150);

         



            Property(c => c.Datanascimento)
                .IsRequired();


            HasRequired(c => c.Usuario)
               .WithMany()
               .HasForeignKey(c => c.UsuarioId);
          


        }

    }
}
