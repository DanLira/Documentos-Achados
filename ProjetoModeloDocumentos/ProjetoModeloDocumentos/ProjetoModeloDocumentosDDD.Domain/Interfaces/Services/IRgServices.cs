

using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Domain.Interfaces.Services
{
   public interface IRgServices : IServicesBase<Rg>
   {
       IEnumerable<Rg> BuscarRg(string nomeDaPessoa, string nomeDaMae, string nomeDoPai, DateTime dataNas);
   }
}
