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
    public class ProgramaRepository: IProgramaRepository
    {
        private readonly AppDbContext _context;
        public ProgramaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Programa>> GetAllAsync()
        {
            return await _context.Programas.ToListAsync();
        }

        public async Task<Programa?> GetByIdAsync(int id)
        {
            return await _context.Programas.FindAsync(id);
        }

        public async Task AddAsync(Programa programa)
        {
            await _context.Programas.AddAsync(programa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Programa programa)
        {
            _context.Programas.Update(programa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var programa = await GetByIdAsync(id);
            if (programa == null)
                throw new Exception($"Programa {id} no encontrado");
            _context.Programas.Remove(programa);
            await _context.SaveChangesAsync();
        }
    }
}
