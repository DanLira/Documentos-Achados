
using System;
using System.Collections.Generic;
using ProjetoModeloDocumentosDDD.Domain.Interfaces;
using ProjetoModeloDocumentosDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDocumentosDDD.Domain.Services
{
   public class ServicesBase<TEntity> : IDisposable , IServicesBase<TEntity> where TEntity : class
   {

       private readonly IRepositoryBase<TEntity> _repository;

       public ServicesBase(IRepositoryBase<TEntity> repository)
       {
           _repository = repository;
       }


       public void Add(TEntity obj)
       {
           
           _repository.Add(obj);

       }

       public TEntity GetById(int id)
       {

           return _repository.GetById(id);
       }


       public IEnumerable<TEntity> GetAll()
       {
           return _repository.GetAll();
       }

       public void Update(TEntity obj)
       {
           
           _repository.Update(obj);

       }

       public void Remove(TEntity obj)
       {
           _repository.Remove(obj);
       }

       public void Dispose()
       {
           _repository.Dispose();
       }
   }
}
