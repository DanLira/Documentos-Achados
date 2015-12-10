

using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Infra.Data.EntityConfig;
using System;


namespace ProjetoModeloDocumentosDDD.Infra.Data.Contexto
{
   public class ProjetoModeloDocumentosContext : DbContext
       
    {

       public ProjetoModeloDocumentosContext()
           : base("ProjetoModeloDocumentos")
       {
           
       }

       public DbSet<UsuarioSystem> UsuarioSystems { get; set; }

       public DbSet<Usuario> Usuarios { get; set; }

       public DbSet<Rg> Rgs { get; set; }

       public DbSet<Cpf> Cpfs { get; set; }

       public DbSet<Cnh> Cnhs { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


           modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(p => p.IsKey());

           modelBuilder.Properties<string>()
               .Configure(p=> p.HasColumnType("varchar"));

           modelBuilder.Properties<string>()
               .Configure(p => p.HasMaxLength(100));

           modelBuilder.Configurations.Add(new UsuarioConfiguration());
           modelBuilder.Configurations.Add(new UsuarioSystemConfiguration());
           modelBuilder.Configurations.Add(new RgConfiguration());
           modelBuilder.Configurations.Add(new CpfConfiguration());
           modelBuilder.Configurations.Add(new CnhConfiguration());
       }

       public override int SaveChanges()
       {
           foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
           {

               if(entry.State == EntityState.Added)
               {
                   entry.Property("DataCadastro").CurrentValue = DateTime.Now;
               }

               if(entry.State == EntityState.Modified)
               {
                   entry.Property("DataCadastro").IsModified = false;
               }
           }
           return base.SaveChanges();
       }
    }
}
