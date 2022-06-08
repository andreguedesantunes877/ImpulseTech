using System;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.ViewModels.Agendamentos;
using Impulse.Domain.ViewModels.Pacientes;

namespace Impulse.Domain.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            ConfigureAgendamentoMap();
            ConfigurePacienteMap();
        }

        private void ConfigureAgendamentoMap()
        {
            CreateMap<AgendamentoCreateViewModel, Agendamento>()
                .ForMember(o => o.DataHoraConsulta,
                    opt => opt.MapFrom(o => new DateTime(o.DataConsulta.Year, o.DataConsulta.Month, o.DataConsulta.Day, o.HoraConsulta.Hour, o.HoraConsulta.Minute, 00)));
        }

        private void ConfigurePacienteMap()
        {
            CreateMap<PacienteCreateViewModel, Paciente>();
        }
    }
}