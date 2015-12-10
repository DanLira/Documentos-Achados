

using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Application.Interface
{
   public interface IUsuarioSystemAppService : IAppServiceBase<UsuarioSystem>
   {
       IEnumerable<UsuarioSystem> Buscar(string login, string senha);
   }
}
