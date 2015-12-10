

using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Application.Interface;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Application
{
  public  class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
  {

      private readonly IServicesBase<TEntity> _servicesBase;

      public AppServiceBase(IServicesBase<TEntity> servicesBase)
      {
          _servicesBase = servicesBase;
      }



      public void Add(TEntity obj)
      {
          _servicesBase.Add(obj);
      }



      public TEntity GetById(int id)
      {
          return _servicesBase.GetById(id);
      }


      public IEnumerable<TEntity> GetAll()
      {
          return _servicesBase.GetAll();
      }

      public void Update(TEntity obj)
      {
          _servicesBase.Update(obj);
      }

      public void Remove(TEntity obj)
      {
          _servicesBase.Remove(obj);
      }

      public void Dispose()
      {
          _servicesBase.Dispose();
      }
  }
}
