



using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;

namespace ProjetoModeloDocumentosDDD.Infra.Data.Repositories
{
   public class RgRepository : RepositoryBase<Rg> , IRgRepository
   {

       public IEnumerable<Rg> BuscarRg(string nomeDaPessoa ,string nomeDaMae, string nomeDoPai ,DateTime dataNas)
       {
           return Db.Rgs.Where(r => r.NomeDaPessoCompleto == nomeDaPessoa && r.NomeMae == nomeDaMae
                                   && r.NomePai == nomeDoPai && r.Datanascimento == dataNas);
          // return Db.Rgs.ToList().Where(r => r.NomeDaPessoCompleto == nomeDaPessoa && r.NomeMae == nomeDaMae
                                           //  && r.NomePai == nomeDoPai && r.Datanascimento == dataNas);
       }
   }
}
