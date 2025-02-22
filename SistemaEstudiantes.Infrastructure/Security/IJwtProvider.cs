using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Domain.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(Usuario usuario);
    }
}
