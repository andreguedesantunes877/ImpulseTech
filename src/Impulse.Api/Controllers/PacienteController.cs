using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace Impulse.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PacienteController : ApiController
    {
        private readonly IPacienteService _pacienteService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pacienteService"></param>
        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }
        
        /// <summary>
        /// Cadastrar ou editar um paciente
        /// </summary>
        /// <param name="pacienteCreateViewModel"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [ProducesResponseType(typeof(Nullable), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post(PacienteCreateViewModel pacienteCreateViewModel)
        {
            try
            {
                var paciente = Mapper.Map<Paciente>(pacienteCreateViewModel);

                if (paciente.Id == 0)
                    _pacienteService.Cadastrar(paciente);
                else
                    _pacienteService.Editar(paciente);

                return new CreatedResult(string.Empty, paciente);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
        
        /// <summary>
        /// Obter Pacientes
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(List<PacientesViewModel>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get()
        {
            try
            {
                var pacientes = _pacienteService.ObterTodos().ToList();
                var pacientesViewModel = Mapper.Map<List<PacientesViewModel>>(pacientes);

                return new OkObjectResult(pacientesViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}