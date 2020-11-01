using SafeTech.Gton.Infra.Data.Models;
using SafeTech.Gton.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Interfaces
{
    public interface IOperationRepository : IBaseRepository<Operation>
    {
        Task<Operation> GetOperationWithHistoryIncludedByIdAsync(int id);
        Task<List<Operation>> GetAllOperationWithHistoryIncludedAsync();

    }
}
