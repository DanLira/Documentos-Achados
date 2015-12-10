

using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
   public class UsuarioServices : ServicesBase<Usuario>, IUsuarioServices
   {
       private readonly IUsuarioRepository _usuarioRepository;

       public UsuarioServices(IUsuarioRepository usuarioRepository)
           :base(usuarioRepository)
       {
           _usuarioRepository = usuarioRepository;
       }
   }
}
