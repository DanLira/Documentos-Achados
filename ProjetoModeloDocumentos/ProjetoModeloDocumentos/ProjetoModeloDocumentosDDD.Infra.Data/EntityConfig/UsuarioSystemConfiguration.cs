

using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig
{
   public class UsuarioSystemConfiguration : EntityTypeConfiguration<UsuarioSystem>
    {
        public UsuarioSystemConfiguration()
        {
            HasKey(c => c.UsuarioSystemId);

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(150);

           

            Property(c => c.senha)
                .IsRequired()
                .HasMaxLength(150);



            Property(c => c.Email)
                .IsRequired();

           

            Property(c => c.Nivel)
                .IsRequired();

        }
    }
}
