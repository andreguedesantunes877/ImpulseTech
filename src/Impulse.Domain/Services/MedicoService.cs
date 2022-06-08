using System.Collections.Generic;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Domain.Interfaces.Services;

namespace Impulse.Domain.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public IEnumerable<Medico> ObterTodos()
        {
            return _medicoRepository.GetAll();
        }
    }
}