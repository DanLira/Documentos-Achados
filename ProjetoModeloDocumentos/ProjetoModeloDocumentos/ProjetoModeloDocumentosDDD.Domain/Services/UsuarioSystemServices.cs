

using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
   public class UsuarioSystemServices : ServicesBase<UsuarioSystem> , IUsuarioSystemServices
   {
       private readonly IUsuarioSystemRepository _usuarioSystemRepository;

       public UsuarioSystemServices(IUsuarioSystemRepository usuarioSystemRepository)
           :base(usuarioSystemRepository)
       {
           _usuarioSystemRepository = usuarioSystemRepository;
       }

       public IEnumerable<UsuarioSystem> Buscar(string login, string senha)
       {
           return _usuarioSystemRepository.Buscar(login, senha);
       }
   }
}
