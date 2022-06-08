using System;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.ViewModels.Agendamentos;

namespace Impulse.Domain.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            ConfigureAgendamentosMap();
        }

        private void ConfigureAgendamentosMap()
        {
            CreateMap<Agendamento, AgendamentosViewModel>()
                .ForMember(o => o.Medico, opt => opt.MapFrom(o => o.Medico.Nome))
                .ForMember(o => o.Paciente, opt => opt.MapFrom(o => o.Paciente.Nome))
                .ForMember(o => o.Data, opt => opt.MapFrom(o => o.DataHoraConsulta.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<Agendamento, AgendamentoCreateViewModel>()
                .ForMember(o => o.DataConsulta, opt => opt.MapFrom(o => new DateTime(o.DataHoraConsulta.Year, o.DataHoraConsulta.Month, o.DataHoraConsulta.Day, 0, 0, 0)))
                .ForMember(o => o.HoraConsulta,
                    opt => opt.MapFrom(o => new DateTime(o.DataHoraConsulta.Year, o.DataHoraConsulta.Month, o.DataHoraConsulta.Day, o.DataHoraConsulta.Hour,
                        o.DataHoraConsulta.Minute, o.DataHoraConsulta.Second)));
        }
    }
}