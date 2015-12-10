using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoModeloDocumentosDDD.Domain.Entites;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
   public class CnhServices : ServicesBase<Cnh> , ICnhServices
   {
       private readonly ICnhRepository _cnhRepository;

       public CnhServices(ICnhRepository cnhRepository)
           :base(cnhRepository)
       {
           _cnhRepository = cnhRepository;
       }
   }
}
