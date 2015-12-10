



using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
   public class UsuarioSystemAppService : AppServiceBase<UsuarioSystem> , IUsuarioSystemAppService
   {

       private readonly IUsuarioSystemServices _usuarioSystemServices;

       public UsuarioSystemAppService(IUsuarioSystemServices usuarioSystemServices)
           :base(usuarioSystemServices)
       {
           _usuarioSystemServices = usuarioSystemServices;
       }


       public IEnumerable<UsuarioSystem> Buscar(string login, string senha)
       {
           return _usuarioSystemServices.Buscar(login, senha);
       }
   }
}
