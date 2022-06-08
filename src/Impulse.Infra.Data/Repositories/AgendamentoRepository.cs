using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Infra.Data.Repositories.Base;

namespace Impulse.Infra.Data.Repositories
{
    public class AgendamentoRepository : RepositoryBase<Agendamento>, IAgendamentoRepository
    {
        public IEnumerable<Agendamento> ObterAgendamentos()
        {
            return Db.Agendamentos.Where(o => o.DataHoraConsulta > DateTime.Now)
                .Include(o => o.Paciente)
                .Include(o => o.Medico).OrderBy(o => o.DataHoraConsulta);
        }
    }
}