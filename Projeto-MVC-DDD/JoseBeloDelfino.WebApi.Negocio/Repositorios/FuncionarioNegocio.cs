using JoseBeloDelfino.Data.Interfaces;
using JoseBeloDelfino.Data.Repositorios;
using JoseBeloDelfino.DTOs;
using JoseBeloDelfino.WebApi.Negocio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JoseBeloDelfino.WebApi.Negocio.Repositorios
{
    public class FuncionarioNegocio : IFuncionarioNegocio
    {
        private IFuncionarioRepositorio _repositorio = new FuncionarioRepositorio();

        public IList<FuncionarioDTO> ListarFuncionarios(string nome)
        {
            return _repositorio.ListarFuncionarios(nome).ToList();
        }

        public FuncionarioDTO ObterFuncionario(int id)
        {
            var funcionario = new FuncionarioDTO();
            if (id == 0)
            {
                funcionario = CarregarCombos(funcionario);
            }
            else
            {
                funcionario = _repositorio.ObterFuncionario(id);
                funcionario = CarregarCombos(funcionario);
            }
            return funcionario;
        }

        public FuncionarioDTO SalvarFuncionario(FuncionarioDTO funcionario)
        {
            return _repositorio.SalvarFuncionario(funcionario);
        }

        public void DeleteFuncionario(int id)
        {
            _repositorio.DeleteFuncionario(id);
        }

        private FuncionarioDTO CarregarCombos(FuncionarioDTO funcionario)
        {
            var supervisores = _repositorio.ListarSupervisores();
            var departamentos = _repositorio.ListarDepartamentos();
            var cargos = _repositorio.ListarCargos();
            funcionario.ComboSupervisor.Add(new SelectListItem() { Text = "Selecione", Value = "", Selected = false });
            funcionario.ComboDepartamento.Add(new SelectListItem() { Text = "Selecione", Value = "", Selected = false });
            funcionario.ComboCargo.Add(new SelectListItem() { Text = "Selecione", Value = "", Selected = false });
            foreach (var item in supervisores)
            {
                funcionario.ComboSupervisor.Add(new SelectListItem() { Text = item.Nome, Value = item.IdFuncionario.ToString(), Selected = funcionario.IdSupervisor == item.IdFuncionario ? true : false });
            }
            foreach (var item in departamentos)
            {
                funcionario.ComboDepartamento.Add(new SelectListItem() { Text = item.NomeDepartamento, Value = item.IdDepartamento.ToString(), Selected = funcionario.IdDepartamento == item.IdDepartamento ? true : false });
            }
            foreach (var item in cargos)
            {
                funcionario.ComboCargo.Add(new SelectListItem() { Text = item.DescricaoCargo, Value = item.IdCargo.ToString(), Selected = funcionario.IdCargo == item.IdCargo ? true : false });
            }

            return funcionario;
        }
    }
}
