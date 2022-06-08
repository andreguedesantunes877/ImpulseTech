using Impulse.Domain.Interfaces.Repositories;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.Services;
using Impulse.Infra.Data.Repositories;
using SimpleInjector;

namespace Impulse.Infra.CrossCuting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            AddAgendaServices(container);
            AddMedicoServices(container);
            AddPacienteServices(container);
            AddUsuarioServices(container);
        }

        private static void AddAgendaServices(Container container)
        {
            container.Register<IAgendamentoService, AgendamentoService>(Lifestyle.Scoped);
            container.Register<IAgendamentoRepository, AgendamentoRepository>(Lifestyle.Scoped);
        }

        private static void AddMedicoServices(Container container)
        {
            container.Register<IMedicoService, MedicoService>(Lifestyle.Scoped);
            container.Register<IMedicoRepository, MedicoRepository>(Lifestyle.Scoped);
        }

        private static void AddPacienteServices(Container container)
        {
            container.Register<IPacienteService, PacienteService>(Lifestyle.Scoped);
            container.Register<IPacienteRepository, PacienteRepository>(Lifestyle.Scoped);
        }

        private static void AddUsuarioServices(Container container)
        {
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
        }
    }
}