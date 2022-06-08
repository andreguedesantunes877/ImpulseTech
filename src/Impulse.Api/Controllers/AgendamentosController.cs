using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Agendamentos;
using Microsoft.AspNetCore.Mvc;
using BadRequestResult = System.Web.Http.Results.BadRequestResult;

namespace Impulse.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AgendamentosController : ApiController
    {
        private readonly IAgendamentoService _agendamentoService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agendamentoService"></param>
        public AgendamentosController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        /// <summary>
        /// Cadastro e edição de agendamento
        /// </summary>
        /// <param name="agendamentoCreateViewModel"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        [ProducesResponseType(typeof(Nullable), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Post(AgendamentoCreateViewModel agendamentoCreateViewModel)
        {
            try
            {
                var agendamento = Mapper.Map<Agendamento>(agendamentoCreateViewModel);

                if (agendamento.Id == 0)
                    _agendamentoService.Cadastrar(agendamento);
                else
                    _agendamentoService.Editar(agendamento);

                return new CreatedResult(string.Empty, agendamento);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        /// <summary>
        /// Obter os agendamentos
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<AgendamentosViewModel>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get()
        {
            try
            {
                var agendamentos = _agendamentoService.ObterAgendamentos();
                var agendamentosViewModel = Mapper.Map<List<AgendamentosViewModel>>(agendamentos);

                return new OkObjectResult(agendamentosViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        /// <summary>
        /// Remove um agendamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var agendamento = _agendamentoService.ObterPorId(id);

                if (agendamento == null)
                    return new NotFoundObjectResult("Agendamento não encontrado");

                _agendamentoService.Remover(agendamento);

                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}