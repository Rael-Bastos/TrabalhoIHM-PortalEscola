﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHM.Domain.Interfaces.Repositorio;

namespace TrabalhoIHM.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EscolaContext _dbContext;

        public Repository(EscolaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where) => await _dbContext.Set<TEntity>().Where(where).ToListAsync();

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
            //query = query.EagerLoad(includes);

            return await query.Where(where).ToListAsync();
        }

        public async Task<int> Count() => await _dbContext.Set<TEntity>().CountAsync();

        public async Task<bool> Existe(Expression<Func<TEntity, bool>> where)
        {
            return await _dbContext.Set<TEntity>().Where(where).AnyAsync();
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
           // query = query.EagerLoad(includes);

            return await query.Where(where).OrderBy(orderBy).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<IList<TEntity>> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>() as IQueryable<TEntity>;
           // query = query.EagerLoad(includes);

            return await query.ToListAsync();
        }
       
        public async Task<TEntity> GetById(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public void Save(TEntity entity) => _dbContext.Add(entity);

        public void SaveMany(IEnumerable<TEntity> entity) => _dbContext.AddRange(entity);

        public void Delete(TEntity entity) => _dbContext.Remove(entity);

        public void DeleteMany(IEnumerable<TEntity> entity) => _dbContext.RemoveRange(entity);

        public void AlterarAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
