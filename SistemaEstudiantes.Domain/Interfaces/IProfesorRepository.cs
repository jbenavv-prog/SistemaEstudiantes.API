using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllAsync();
        Task<Profesor?> GetByIdAsync(int id);
        Task AddAsync(Profesor profesor);
        Task UpdateAsync(Profesor profesor);
        Task DeleteAsync(int id);
    }
}
