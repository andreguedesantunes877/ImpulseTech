using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Agendamentos;

namespace Impulse.App.Controllers
{
    [Authorize]
    public class AgendamentosController : Controller
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IPacienteService _pacienteService;
        private readonly IMedicoService _medicoService;

        public AgendamentosController(IAgendamentoService agendamentoService, IPacienteService pacienteService, IMedicoService medicoService)
        {
            _agendamentoService = agendamentoService;
            _pacienteService = pacienteService;
            _medicoService = medicoService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var agendamentos = _agendamentoService.ObterAgendamentos();
                var agendamentosViewModel = Mapper.Map<IEnumerable<AgendamentosViewModel>>(agendamentos);
            
                return View(agendamentosViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                ViewBag.PacienteId = new SelectList(_pacienteService.ObterTodos().ToList(), "Id", "Nome");
                ViewBag.MedicoId = new SelectList(_medicoService.ObterTodos().ToList(), "Id", "Nome");
            
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult Create(AgendamentoCreateViewModel agendamentoCreateViewModel)
        {
            try
            {
                var agendamento = Mapper.Map<Agendamento>(agendamentoCreateViewModel);
            
                if (agendamento.Id == 0)
                    _agendamentoService.Cadastrar(agendamento);
                else
                    _agendamentoService.Editar(agendamento);
            
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var agendamento = _agendamentoService.ObterPorId(id);

                if (agendamento == null)
                    throw new Exception("Agendamento não localizado na base de dados");

                var agendamentoViewModel = Mapper.Map<AgendamentoCreateViewModel>(agendamento);
            
                ViewBag.PacienteId = new SelectList(_pacienteService.ObterTodos().ToList(), "Id", "Nome", agendamentoViewModel.PacienteId);
                ViewBag.MedicoId = new SelectList(_medicoService.ObterTodos().ToList(), "Id", "Nome", agendamentoViewModel.MedicoId);

                ViewBag.DataConsulta = agendamentoViewModel.DataConsulta.ToString("dd/MM/yyyy");
            
                return View(agendamentoViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var agendamento = _agendamentoService.ObterPorId(id);

                if (agendamento == null)
                    throw new Exception("Agendamento não localizado na base de dados");

                _agendamentoService.Remover(agendamento);
            
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}