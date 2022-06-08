using Bogus;
using Bogus.Extensions.Brazil;
using Impulse.Domain.Entities;

namespace Impulse.Domain.Tests.Pacientes
{
    public class PacienteTestsFixture
    {
        private const string Locale = "pt_BR";
        
        public Paciente ObterPacienteValido()
        {
            var paciente = new Faker<Paciente>(Locale).CustomInstantiator(f => new Paciente
            {
                Nome = f.Person.FullName, Documento = f.Person.Cpf(false), NumeroConvenio = f.Random.Int(10, 10).ToString()
            });

            return paciente;
        }
        
        public Paciente ObterPacienteSemNome()
        {
            var paciente = new Faker<Paciente>(Locale).CustomInstantiator(f => new Paciente
            {
                Nome = null, Documento = f.Person.Cpf(false), NumeroConvenio = f.Random.Int(10, 10).ToString()
            });

            return paciente;
        }
    }
}