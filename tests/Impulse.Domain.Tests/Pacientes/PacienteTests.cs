using NUnit.Framework;

namespace Impulse.Domain.Tests.Pacientes
{
    public class PacienteTests
    {
        private PacienteTestsFixture _pacienteTestsFixture;
        
        [SetUp]
        public void SetUp()
        {
            _pacienteTestsFixture = new PacienteTestsFixture();
        }
        
        [Test]
        public void Paciente_Validar_DeveSerValido()
        {
            // Arrange
            var paciente = _pacienteTestsFixture.ObterPacienteValido();
            
            // Action
            var resultado = paciente.Validar();
            
            // Assert
            Assert.IsTrue(resultado.IsValid);
        }
        
        [Test]
        public void Paciente_Validar_DeveValidarNomeNaoInformado()
        {
            // Arrange
            var paciente = _pacienteTestsFixture.ObterPacienteSemNome();
            
            // Action
            var resultado = paciente.Validar();
            
            // Assert
            Assert.IsFalse(resultado.IsValid);
        }
    }
}