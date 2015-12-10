

using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
  public  class CpfServices : ServicesBase<Cpf> , ICpfServices
  {

      private readonly ICpfRepository _cpfRepository;

      public CpfServices(ICpfRepository cpfRepository)
          :base(cpfRepository)
      {
          _cpfRepository = cpfRepository;
      }
  }
}
