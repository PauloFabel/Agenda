using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Agenda.Data.Context;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Base
    {
        internal Contexto _context;
        internal DbSet<TEntity> _dbSet;

        public RepositoryBase(Contexto context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();

        }

        //Método que adiciona um objeto.

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

        }

        //Método que adiciona todos os objetos

        public void AddAll(List<TEntity> entity)
        {

            foreach (var item in entity)
            {

                _dbSet.Add(item);
            }

            _context.SaveChanges();

        }

        /// Método que deleta um objeto no banco de dados da aplicação.
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {

                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        public void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            List<TEntity> listDelete = query.Where(filter).ToList();

            foreach (var item in listDelete)
            {
                _dbSet.Remove(item);
            }

            _context.SaveChanges();

        }

        public void Dispose()
        {
            _dbSet = null;
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Edit(TEntity entity)
        {
            var pkey = entity.Id;

            TEntity attachedEntity = _dbSet.Find(pkey); //Acessa a chave primaria

            if (attachedEntity != null)
            {
                _dbSet.Update(entity);
            }


            _context.SaveChanges();

        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {

                query = query.Where(filter);

            }

            if (orderBy != null)
            {

                return orderBy(query).ToList();

            }
            else
            {
                return query.ToList();
            }
        }
    }
}
