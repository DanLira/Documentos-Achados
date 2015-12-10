
using System.Data.Entity.ModelConfiguration;

using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig
{
  public  class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
  {

      public UsuarioConfiguration()
      {
          HasKey(c => c.UsuarioId);

          Property(c => c.Nome)
              .IsRequired()
              .HasMaxLength(150);

          Property(c => c.SobreNome)
              .IsRequired()
              .HasMaxLength(150);

          Property(c => c.Email)
              .IsRequired();

          Property(c => c.Cpf)
              .IsRequired()
              .HasMaxLength(11);

          Property(c => c.Cep)
              .IsRequired()
              .HasMaxLength(12);

          Property(c => c.Login)
              .IsRequired()
              .HasMaxLength(30);

          Property(c => c.Senha)
              .IsRequired()
              .HasMaxLength(30);

            Property(c => c.Telefone)
             .IsRequired()
             .HasMaxLength(12);


        }
  }
}
