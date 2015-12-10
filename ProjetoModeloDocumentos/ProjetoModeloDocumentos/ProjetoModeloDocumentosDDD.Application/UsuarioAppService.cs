

using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
  public  class UsuarioAppService : AppServiceBase<Usuario> ,IUsuarioAppService
  {

      private readonly IUsuarioServices _usuarioServices;

      public UsuarioAppService(IUsuarioServices usuarioServices)
          :base(usuarioServices)
      {
          _usuarioServices = usuarioServices;
      }
  }
}
