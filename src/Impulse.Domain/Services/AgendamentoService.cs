using System.Collections.Generic;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Domain.Interfaces.Services;

namespace Impulse.Domain.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public Agendamento Cadastrar(Agendamento agendamento)
        {
            return _agendamentoRepository.Add(agendamento);
        }

        public Agendamento Editar(Agendamento agendamento)
        {
            return _agendamentoRepository.Update(agendamento);
        }

        public void Remover(Agendamento agendamento)
        {
            _agendamentoRepository.Remove(agendamento);
        }

        public IEnumerable<Agendamento> ObterAgendamentos()
        {
            return _agendamentoRepository.ObterAgendamentos();
        }

        public Agendamento ObterPorId(int id)
        {
            return _agendamentoRepository.GetById(id);
        }
    }
}