using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Medicos;
using Microsoft.AspNetCore.Mvc;

namespace Impulse.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class MedicosController : ApiController
    {
        private readonly IMedicoService _medicoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicoService"></param>
        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        /// <summary>
        /// Obter uma lista de médicos
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(List<MedicoViewModel>), 200)]
        public IActionResult Get()
        {
            try
            {
                var medicos = _medicoService.ObterTodos().ToList();
                var medicosViewModel = Mapper.Map<List<MedicoViewModel>>(medicos);

                return new OkObjectResult(medicosViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}