using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Impulse.Domain.Interfaces.Services;
using Impulse.Domain.ViewModels.Agendamentos;
using Impulse.Domain.ViewModels.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Impulse.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioService"></param>
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [ProducesResponseType(typeof(List<UsuariosViewModel>), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioService.ObterTodos().ToList();
                var usuariosViewModel = Mapper.Map<List<UsuariosViewModel>>(usuarios);

                return new OkObjectResult(usuariosViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}