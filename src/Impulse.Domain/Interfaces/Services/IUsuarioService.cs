using System.Collections.Generic;
using Impulse.Domain.Entities;

namespace Impulse.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObterTodos();

        Usuario ObterPorDocumento(string documento);
    }
}