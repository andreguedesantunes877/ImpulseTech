using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Pacientes;

namespace Impulse.App.Controllers
{
    [Authorize]
    public class PacientesController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var pacientes = _pacienteService.ObterTodos().ToList();
                var pacientesViewModel = Mapper.Map<List<PacientesViewModel>>(pacientes);
            
                return View(pacientesViewModel);
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(PacienteCreateViewModel pacienteCreateViewModel)
        {
            try
            {
                var paciente = Mapper.Map<Paciente>(pacienteCreateViewModel);
                _pacienteService.Cadastrar(paciente);
            
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
                var paciente = _pacienteService.ObterPorId(id);

                if (paciente == null)
                    throw new Exception("Paciente não localizado na base de dados");

                var pacienteViewModel = Mapper.Map<PacienteCreateViewModel>(paciente);
                return View(pacienteViewModel);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
    }
}