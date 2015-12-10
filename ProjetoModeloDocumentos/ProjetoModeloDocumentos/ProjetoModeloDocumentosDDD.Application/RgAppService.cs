




using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
  public  class RgAppService : AppServiceBase<Rg> ,IRgAppService
  {

      private readonly IRgServices _rgServices;

      public RgAppService(IRgServices rgServices)
          :base(rgServices)
      {
          _rgServices = rgServices;
      }



      public IEnumerable<Rg> BuscarRg(string nomeDaPessoa, string nomeDaMae, string nomeDoPai, DateTime dataNas)
      {
          return _rgServices.BuscarRg(nomeDaPessoa, nomeDaMae, nomeDoPai,dataNas);
      }
  }
}
