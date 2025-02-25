using Microsoft.EntityFrameworkCore;
using SistemaEstudiantes.Domain.Entities;
using SistemaEstudiantes.Domain.Interfaces;
using SistemaEstudiantes.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Infrastructure.Repositories
{
    public class UsuarioMateriaRepository: IUsuarioMateriaRepository
    {
        private readonly AppDbContext _context;
        public UsuarioMateriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioMateria>> GetAllAsync()
        {
            return await _context.UsuarioMaterias.ToListAsync();
        }

        public async Task<UsuarioMateria?> GetByUsuarioMateriaAsync(UsuarioMateria usuarioMateria) {
            return await _context.UsuarioMaterias
                .Where(um => um.IDUsuario == usuarioMateria.IDUsuario && um.IDMateria == usuarioMateria.IDMateria)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetUsuariosByMateriaIdAsync(int idMateria)
        {
            return await _context.UsuarioMaterias
                .Where(um => um.IDMateria == idMateria && um.Usuario != null) // Filtra nulos
                .Include(um => um.Usuario)
                .Select(um => um.Usuario!) // Confirma que nunca será null
                .ToListAsync();
        }

        public async Task<UsuarioMateria?> GetByIdAsync(int id)
        {
            return await _context.UsuarioMaterias.FindAsync(id);
        }

        public async Task<List<UsuarioMateria>> GetByIdUsuarioAsync(int usuarioId)
        {
            return await _context.UsuarioMaterias
                .Where(um => um.IDUsuario == usuarioId)
                .ToListAsync();
        }

        public async Task AddAsync(UsuarioMateria usuarioMateria)
        {
            await _context.UsuarioMaterias.AddAsync(usuarioMateria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioMateria usuarioMateria)
        {
            _context.UsuarioMaterias.Update(usuarioMateria);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuarioMateria = await GetByIdAsync(id);
            if (usuarioMateria == null)
                throw new Exception($"Materia {id} no encontrado");
            _context.UsuarioMaterias.Remove(usuarioMateria);
            await _context.SaveChangesAsync();
        }
    }
}
