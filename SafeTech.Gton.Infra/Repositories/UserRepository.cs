using Microsoft.EntityFrameworkCore;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GtonContext context) : base(context)
        {
        }

        public Task<User> GetUserWithUnityAndOperationsByIdAsync(int id)
        {
            return db
                .Include(x => x.MedicalUnity)
                .ThenInclude(x => x.OperationSourceCollection)
                .ThenInclude(x => x.Organ)
                .ThenInclude(x => x.OrganType)
                .Include(x => x.MedicalUnity)
                .ThenInclude(x => x.OperationSourceCollection)
                .ThenInclude(x => x.OperationHistoryCollection)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
