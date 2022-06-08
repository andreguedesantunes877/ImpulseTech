using System.Web.Mvc;
using System.Web.Security;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Autenticacao;

namespace Impulse.App.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(AutenticacaoViewModel autenticacaoViewModel)
        {
            var usuario = _usuarioService.ObterPorDocumento(autenticacaoViewModel.Documento);

            if (usuario == null)
            {
                ViewBag.Message = "Usuário ou senha incorretos";
                return View();
            }

            if (usuario.Senha != autenticacaoViewModel.Senha)
            {
                ViewBag.Message = "Usuário ou senha incorretos";
                return View();
            }
            
            FormsAuthentication.SetAuthCookie(autenticacaoViewModel.Documento, false);
            
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}