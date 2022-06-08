using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Impulse.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Impulse.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthTokensController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioService"></param>
        public AuthTokensController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documento"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult Get(string documento, string senha)
        {
            var usuario = _usuarioService.ObterPorDocumento(documento);

            if (usuario == null)
                return new NotFoundObjectResult("Usuário não encontrado");

            if (usuario.Senha != senha)
                return new BadRequestObjectResult("Usuário ou senha incorretos");
            
            return new OkObjectResult(usuario.Senha);
        }
    }
}