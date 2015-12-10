

using System;

using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;

namespace ProjetoModeloDocumentosDDD.Domain.Interfaces
{
   public interface IRgRepository : IRepositoryBase<Rg>

   {
      IEnumerable<Rg> BuscarRg(string nomeDaPessoa, string nomeDaMae, string nomeDoPai, DateTime dataNas);
   }
}
