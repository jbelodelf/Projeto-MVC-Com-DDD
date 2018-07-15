using JoseBeloDelfino.Negocio.InterfacesApp;
using JoseBeloDelfino.Services.Interfaces;
using JoseBeloDelfino.ViewModels;
using System.Collections.Generic;

namespace JoseBeloDelfino.Negocio.RepositoriesApp
{
    public class FuncionarioNegocio : IFuncionarioNegocio
    {
        private IFuncionarioServiceRepositorio _repositorio;

        public FuncionarioNegocio(IFuncionarioServiceRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<FuncionarioViewModel> ListarFuncionarios(string nome, string Token)
        {
            return _repositorio.ListarFuncionarios(nome, Token);
        }

        public FuncionarioViewModel ObterFuncionario(int id, string token)
        {
            return _repositorio.ObterFuncionario(id, token);
        }

        public FuncionarioViewModel SalvarFuncionario(FuncionarioViewModel funcionario, string token)
        {
            return _repositorio.SalvarFuncionario(funcionario, token);
        }

        public string DeleteFuncionario(int id, string token)
        {
            return _repositorio.DeleteFuncionario(id, token);
        }
    }
}
