using JoseBeloDelfino.Domain.Entidades;
using System.Collections.Generic;

namespace JoseBeloDelfino.Business.Interfaces
{
    public interface IUsuarioNegocio
    {
        List<UsuarioEntity> ListarUsuarios();
    }
}
