using JoseBeloDelfino.DTOs;
using System.Collections.Generic;

namespace JoseBeloDelfino.WebApi.Negocio.Interfaces
{
    public interface IFuncionarioNegocio
    {
        IList<FuncionarioDTO> ListarFuncionarios(string nome);
        FuncionarioDTO ObterFuncionario(int id);
        FuncionarioDTO SalvarFuncionario(FuncionarioDTO funcionario);
        void DeleteFuncionario(int id);

    }
}
