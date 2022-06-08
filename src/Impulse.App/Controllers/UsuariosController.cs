using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Usuarios;

namespace Impulse.App.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ActionResult Index()
        {
            var usuarios = _usuarioService.ObterTodos().ToList();
            var usuariosViewModel = Mapper.Map<List<UsuariosViewModel>>(usuarios);
            
            return View(usuariosViewModel);
        }
    }
}