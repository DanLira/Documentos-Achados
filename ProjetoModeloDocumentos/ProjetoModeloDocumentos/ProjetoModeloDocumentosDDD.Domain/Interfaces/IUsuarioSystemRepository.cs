

using System.Collections;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Domain.Interfaces
{
   public interface IUsuarioSystemRepository : IRepositoryBase<UsuarioSystem>
   {

       IEnumerable<UsuarioSystem> Buscar(string login, string senha);
   }
}
