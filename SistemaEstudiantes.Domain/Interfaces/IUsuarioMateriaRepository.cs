using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Interfaces
{
    public interface IUsuarioMateriaRepository
    {
        Task<IEnumerable<UsuarioMateria>> GetAllAsync();
        Task<UsuarioMateria?> GetByUsuarioMateriaAsync(UsuarioMateria usuarioMateria);
        Task<List<Usuario>> GetUsuariosByMateriaIdAsync(int idMateria);
        Task<UsuarioMateria?> GetByIdAsync(int id);
        Task<List<UsuarioMateria>> GetByIdUsuarioAsync(int usuarioId);
        Task AddAsync(UsuarioMateria usuarioMateria);
        Task UpdateAsync(UsuarioMateria usuarioMateria);
        Task DeleteAsync(int id);
    }
}
