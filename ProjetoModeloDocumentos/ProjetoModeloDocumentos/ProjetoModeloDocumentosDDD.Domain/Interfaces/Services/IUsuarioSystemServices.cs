

using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Domain.Interfaces.Services
{
  public  interface IUsuarioSystemServices : IServicesBase<UsuarioSystem>
    {
      IEnumerable<UsuarioSystem> Buscar(string login, string senha);
    }
}
