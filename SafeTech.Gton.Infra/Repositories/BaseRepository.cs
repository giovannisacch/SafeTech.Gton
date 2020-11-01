using Microsoft.EntityFrameworkCore;
using SafeTech.Gton.Infra.Data.Models;
using SafeTech.Gton.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly GtonContext ctx;
        protected readonly DbSet<T> db;
        public BaseRepository(GtonContext context)
        {
            ctx = context;
            db = context.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            ctx.Set<T>().Add(entity);
            await ctx.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            ctx.Set<T>().Remove(entity);
            await ctx.SaveChangesAsync();
        }

        public virtual Task<List<T>> FindAllAsync(bool asNoTracking = false)
        {
            if (asNoTracking)
                return ctx.Set<T>().AsNoTracking().ToListAsync(); 

            return ctx.Set<T>().ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await ctx.Set<T>()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id );

            return await ctx.Set<T>().FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            ctx.Set<T>().Update(entity);
            await ctx.SaveChangesAsync();
        }
    }
}
