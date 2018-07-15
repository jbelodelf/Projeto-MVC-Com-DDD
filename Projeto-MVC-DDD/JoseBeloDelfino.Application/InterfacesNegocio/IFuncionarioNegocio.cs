using JoseBeloDelfino.ViewModels;
using System.Collections.Generic;

namespace JoseBeloDelfino.Negocio.InterfacesApp
{
    public interface IFuncionarioNegocio
    {
        FuncionarioViewModel ObterFuncionario(int id, string token);
        List<FuncionarioViewModel> ListarFuncionarios(string nome, string Token);
        FuncionarioViewModel SalvarFuncionario(FuncionarioViewModel funcionario, string token);
        string DeleteFuncionario(int id, string token);
    }
}
