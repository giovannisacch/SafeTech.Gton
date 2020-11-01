using SafeTech.Gton.Infra.Data.Models;
using SafeTech.Gton.Service.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeTech.Gton.Infra.Data.Interfaces
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<bool> CpfIsAlreadyRegistered(string cpf);
    }
}
