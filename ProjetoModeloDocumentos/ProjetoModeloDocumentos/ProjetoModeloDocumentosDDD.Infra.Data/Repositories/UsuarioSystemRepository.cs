

using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;

namespace ProjetoModeloDocumentosDDD.Infra.Data.Repositories
{
   public class UsuarioSystemRepository : RepositoryBase<UsuarioSystem> , IUsuarioSystemRepository
   {
       public IEnumerable<UsuarioSystem> Buscar(string login, string senha)
       {
           return Db.UsuarioSystems.Where(u => u.Login.Equals(login)&& u.senha.Equals(senha));
       }
   }
}
