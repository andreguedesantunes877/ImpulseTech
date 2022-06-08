using System;
using System.Collections.Generic;
using System.Linq;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Domain.Interfaces.Services;

namespace Impulse.Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public Paciente Cadastrar(Paciente paciente)
        {
            var resultadoValidacao = paciente.Validar();

            if (!resultadoValidacao.IsValid)
                throw new Exception(resultadoValidacao.Errors.FirstOrDefault()?.ErrorMessage);

            _pacienteRepository.Add(paciente);

            return paciente;
        }

        public IEnumerable<Paciente> ObterTodos()
        {
            return _pacienteRepository.GetAll();
        }

        public Paciente ObterPorId(int id)
        {
            return _pacienteRepository.GetById(id);
        }

        public Paciente Editar(Paciente paciente)
        {
            return _pacienteRepository.Update(paciente);
        }
    }
}