using System.Collections.Generic;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories.Base;

namespace Impulse.Domain.Interfaces.Repositories
{
    public interface IAgendamentoRepository : IRepositoryBase<Agendamento>
    {
        IEnumerable<Agendamento> ObterAgendamentos();
    }
}