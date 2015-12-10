



using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
   public class CpfAppService : AppServiceBase<Cpf> ,ICpfAppService
   {

       private readonly ICpfServices _cpfServices;

       public CpfAppService(ICpfServices cpfServices)
           :base(cpfServices)
       {
           _cpfServices = cpfServices;
       }
   }
}
