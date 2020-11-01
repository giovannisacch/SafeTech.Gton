using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SafeTech.Gton.Infra.Data.Interfaces;
using SafeTech.Gton.Infra.Data.Models;
using SafeTech.Gton.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(GtonContext context) : base(context)
        {
        }

        public async Task<bool> CpfIsAlreadyRegistered(string cpf)
        {
            return await db.AnyAsync(x => x.CPF == cpf);
        }
    }
}
