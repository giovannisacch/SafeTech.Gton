using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Service.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<List<T>> FindAllAsync(bool asNoTracking = false);
        Task<T> FindByIdAsync(int id, bool asNoTracking = false);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity); 
    }
}
