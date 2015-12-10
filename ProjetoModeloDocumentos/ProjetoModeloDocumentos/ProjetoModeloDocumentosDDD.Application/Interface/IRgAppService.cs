
using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Application.Interface
{
   public interface IRgAppService : IAppServiceBase<Rg>
   {
       IEnumerable<Rg> BuscarRg(string nomeDaPessoa, string nomeDaMae, string nomeDoPai, DateTime dataNas);
   }
}
