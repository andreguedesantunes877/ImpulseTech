using System.Linq;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Infra.Data.Repositories.Base;

namespace Impulse.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario ObterPorDocumento(string documento)
        {
            return Db.Usuarios.FirstOrDefault(o => o.Documento == documento);
        }
    }
}