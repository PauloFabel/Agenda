using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Data.Repository
{
    /// <summary>
    /// Interface com todos os métodos que deverão ser implementados para as modificações no banco.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class 
    {
        void Add(TEntity entity);
        void AddAll(List<TEntity> entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        void DeleteAll(Expression<Func<TEntity, bool>> filter = null);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);

    }
}
