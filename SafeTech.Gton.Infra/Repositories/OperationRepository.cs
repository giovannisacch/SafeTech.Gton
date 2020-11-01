using Microsoft.EntityFrameworkCore;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Repositories
{
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        public OperationRepository(GtonContext context) : base(context)
        {
        }

        public async Task<List<Operation>> GetAllOperationWithHistoryIncludedAsync()
        {
            return await db.Include(x => x.OperationHistoryCollection).ToListAsync();
        }

        public async Task<Operation> GetOperationWithHistoryIncludedByIdAsync(int id)
        {
            return await db
                        .Include(x => x.OperationHistoryCollection)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
