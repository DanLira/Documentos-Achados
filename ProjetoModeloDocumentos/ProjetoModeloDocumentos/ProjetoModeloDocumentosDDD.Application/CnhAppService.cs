



using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
   public class CnhAppService : AppServiceBase<Cnh> , ICnhAppService
   {
       private readonly ICnhServices _cnhServices;

       public CnhAppService(ICnhServices cnhServices)
           :base(cnhServices)
       {
           _cnhServices = cnhServices;
       }
   }
}
