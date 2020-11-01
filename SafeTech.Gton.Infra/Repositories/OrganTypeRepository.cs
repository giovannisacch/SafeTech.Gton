using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeTech.Gton.Infra.Data.Repositories
{
    public class OrganTypeRepository : BaseRepository<OrganType>, IOrganTypeRepository
    {
        public OrganTypeRepository(GtonContext context) : base(context)
        {
        }
    }
}
