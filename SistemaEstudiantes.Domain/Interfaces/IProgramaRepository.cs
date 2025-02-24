using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Interfaces
{
    public interface IProgramaRepository
    {
        Task<IEnumerable<Programa>> GetAllAsync();
        Task<Programa?> GetByIdAsync(int id);
        Task AddAsync(Programa programa);
        Task UpdateAsync(Programa programa);
        Task DeleteAsync(int id);
    }
}
