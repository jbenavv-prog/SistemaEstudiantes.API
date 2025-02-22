using SistemaEstudiantes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudiantes.Infrastructure.Security
{
    public interface IJwtProvider
    {
        string GenerateToken(string IDUsuario);
    }
}
