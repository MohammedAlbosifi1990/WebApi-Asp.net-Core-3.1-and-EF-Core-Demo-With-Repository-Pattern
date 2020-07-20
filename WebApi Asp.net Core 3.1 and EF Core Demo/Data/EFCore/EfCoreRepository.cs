using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.EFCore
{
    public abstract class EfCoreRepository<TEntity, TContext> : IGenericRepository<TEntity>
         where TEntity : class, IEntity
         where TContext : DemoDBContext
    {
        private readonly TContext context;
        public EfCoreRepository(TContext context)
        {
            this.context = context;
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
            return await context.Set<TEntity>().Include(t => (t as UserInfo).Messages).FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().Include(t => (t as UserInfo).Messages).ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
