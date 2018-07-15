using JoseBeloDelfino.Domain.Entidades;
using JoseBeloDelfino.Domain.Interfaces;
using System.Collections.Generic;

namespace JoseBeloDelfino.Business.Repositorios
{
    public class UsuarioNegocio
    {
        private IUsuarioRepositorio usuarioRepositorio;

        public List<UsuarioEntity> ListarUsuarios()
        {
            var usuarios = usuarioRepositorio.ListarUsuarios();
            return usuarios;
        }
    }
}
