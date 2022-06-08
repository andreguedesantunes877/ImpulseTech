using System.Collections.Generic;
using Impulse.Domain.Entities;

namespace Impulse.Domain.Interfaces.Services
{
    public interface IAgendamentoService
    {
        Agendamento Cadastrar(Agendamento agendamento);
        
        IEnumerable<Agendamento> ObterAgendamentos();

        Agendamento ObterPorId(int id);

        Agendamento Editar(Agendamento agendamento);

        void Remover(Agendamento agendamento);
    }
}