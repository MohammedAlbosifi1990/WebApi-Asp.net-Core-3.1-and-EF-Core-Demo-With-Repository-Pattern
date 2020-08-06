using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.EFCore
{
    public abstract class EfCoreRepository<TEntity, TContext> : IGenericRepository<TEntity>
         where TEntity : class, IEntity
         where TContext : DemoDBContext
    {
        private readonly TContext context;
        private DbSet<TEntity> dbSet;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetWithInclude(Expression<Func<TEntity, object>> includes)
        {
            return await context.Set<TEntity>().Include(includes).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWithMultiInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Get2(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            //List<Model> modelList = _unitOfWork.ModelRepository.Get(m => m.FirstName == "Jan" || m.LastName == "Holinka", includeProperties: "Account");
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null,
                                         Func<IQueryable<TEntity>,
                                         IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public async Task<TEntity> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null
                                                    , params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(filter);
        }






    }
}
