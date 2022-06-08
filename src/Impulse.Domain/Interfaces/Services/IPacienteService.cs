using System.Collections.Generic;
using Impulse.Domain.Entities;

namespace Impulse.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Paciente Cadastrar(Paciente paciente);
        
        IEnumerable<Paciente> ObterTodos();

        Paciente ObterPorId(int id);

        Paciente Editar(Paciente paciente);
    }
}