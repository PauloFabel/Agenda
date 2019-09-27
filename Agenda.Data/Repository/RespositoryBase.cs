using Agenda.Data.Context;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Agenda.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : Base
    {
        internal Contexto _context;
        internal DbSet<TEntity> _dbSet;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="context"></param>
        public RepositoryBase(Contexto context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();

        }

        /// <summary>
        /// Método que adiciona um objeto.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

        }

        /// <summary>
        /// Método que adiciona uma lista de novos objetos ao banco de dados da aplicação.
        /// </summary>
        /// <param name="entity"></param>
        public void AddAll(List<TEntity> entity)
        {

            foreach (var item in entity)
            {

                _dbSet.Add(item);
            }

            _context.SaveChanges();

        }

        /// <summary>
        /// Método que deleta um objeto no banco de dados da aplicação.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {

                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();

        }

        /// <summary>
        /// Método que deleta um ou varios objetos no banco de dados da aplicação, mediante uma expressão LINQ.
        /// </summary>
        /// <param name="filter"></param>

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

        /// <summary>
        /// Método que limpa a memória.
        /// </summary>
        public void Dispose()
        {
            _dbSet = null;
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Método que atualiza um registro da tabela no banco de dados.
        /// </summary>
        /// <param name="entity"></param>
        public void Edit(TEntity entity)
        {
            if (entity != null)
            {
               
                    _dbSet.Update(entity);
                                   
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// Método que busca uma lista de objetos no banco de dados da aplicação e retorna-a no tipo IEnumerable<TEntity>
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();

        }
    }
}
