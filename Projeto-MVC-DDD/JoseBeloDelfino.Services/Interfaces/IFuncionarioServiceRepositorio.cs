using JoseBeloDelfino.ViewModels;
using System.Collections.Generic;

namespace JoseBeloDelfino.Services.Interfaces
{
    public interface IFuncionarioServiceRepositorio
    {
        List<FuncionarioViewModel> ListarFuncionarios(string nome, string token);
        FuncionarioViewModel ObterFuncionario(int id, string token);
        FuncionarioViewModel SalvarFuncionario(FuncionarioViewModel funcionario, string token);
        string DeleteFuncionario(int id, string token);
    }
}
