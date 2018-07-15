using JoseBeloDelfino.DTOs;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JoseBeloDelfino.Data.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        FuncionarioDTO ObterFuncionario(int id);
        List<FuncionarioDTO> ListarFuncionarios(string nome);
        FuncionarioDTO SalvarFuncionario(FuncionarioDTO funcionario);
        void DeleteFuncionario(int id);

        List<CargoDTO> ListarCargos();
        List<DepartamentoDTO> ListarDepartamentos();
        List<FuncionarioDTO> ListarSupervisores();
    }
}
