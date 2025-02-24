using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Interfaces
{
    public interface IMateriaRepository
    {
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<Materia?> GetByIdAsync(int id);
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(int id);
    }
}
