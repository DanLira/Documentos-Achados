

using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
   public class RgServices : ServicesBase<Rg> , IRgServices
   {

       private readonly IRgRepository _rgRepository;

       public RgServices(IRgRepository rgRepository)
           :base(rgRepository)
       {
           _rgRepository = rgRepository;
       }



       public IEnumerable<Rg> BuscarRg(string nomeDaPessoa, string nomeDaMae, string nomeDoPai, DateTime dataNas)
       {
           return _rgRepository.BuscarRg(nomeDaPessoa, nomeDaMae, nomeDoPai,dataNas);
       }
   }
}
