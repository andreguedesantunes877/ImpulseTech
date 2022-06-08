using System.Collections.Generic;
using Impulse.Domain.Entities;
using Impulse.Domain.Interfaces.Repositories;
using Impulse.Domain.Interfaces.Services;

namespace Impulse.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario ObterPorDocumento(string documento)
        {
            return _usuarioRepository.ObterPorDocumento(documento);
        }
    }
}