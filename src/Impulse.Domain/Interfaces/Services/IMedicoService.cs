using System.Collections.Generic;
using Impulse.Domain.Entities;

namespace Impulse.Domain.Interfaces.Services
{
    public interface IMedicoService
    {
        IEnumerable<Medico> ObterTodos();
    }
}