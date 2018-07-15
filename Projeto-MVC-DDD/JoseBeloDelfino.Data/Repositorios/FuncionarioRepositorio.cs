using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using JoseBeloDelfino.Data.Interfaces;
using JoseBeloDelfino.Domain.Entidades;
using JoseBeloDelfino.DTOs;

namespace JoseBeloDelfino.Data.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        public List<FuncionarioDTO> ListarFuncionarios(string nome)
        {
            List<FuncionarioEntity> funcionarios = null;
            string[] includes = new string[] { "Cargo", "Departamento" };
            Expression<Func<FuncionarioEntity, bool>> expressionFiltro = (a => a.Nome.Contains(nome));

            using (var repositorio = new RepositorioBase<FuncionarioEntity>())
            {
                funcionarios = repositorio.Select(expressionFiltro, includes).ToList();
            }

            var funcionarioDTO = Mapper.Map<List<FuncionarioEntity>, List<FuncionarioDTO>>(funcionarios);
            return funcionarioDTO;
        }

        public FuncionarioDTO ObterFuncionario(int id)
        {
            FuncionarioEntity funcionario = null;

            string[] includes = new string[] { "Cargo", "Departamento" };
            Expression<Func<FuncionarioEntity, bool>> expressionFiltro = (a => a.IdFuncionario == id);

            using (var repositorio = new RepositorioBase<FuncionarioEntity>())
            {
                funcionario = repositorio.Select(expressionFiltro, includes).FirstOrDefault();
            }

            var funcionarioDTO = Mapper.Map<FuncionarioEntity, FuncionarioDTO>(funcionario);
            return funcionarioDTO;
        }

        public FuncionarioDTO SalvarFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarioEntity = Mapper.Map<FuncionarioDTO, FuncionarioEntity>(funcionario);
            using (var repositorio = new RepositorioBase<FuncionarioEntity>())
            {
                if(funcionario.IdFuncionario > 0)
                    repositorio.Update(funcionarioEntity);
                else
                    repositorio.Insert(funcionarioEntity);
            }

            return funcionario;
        }

        public void DeleteFuncionario(int id)
        {
            Expression<Func<FuncionarioEntity, bool>> expressionFiltro1 = (c => c.IdFuncionario == id);
            using (var repositorio = new RepositorioBase<FuncionarioEntity>())
            {
                repositorio.Delete(expressionFiltro1);
            }
        }

        public List<CargoDTO> ListarCargos()
        {
            var cargosDTO = new List<CargoDTO>();
            using (var repositorio = new RepositorioBase<CargoEntity>())
            {
                var cargos = repositorio.Select().ToList();
                cargosDTO = Mapper.Map< List<CargoEntity>, List<CargoDTO>>(cargos);
            }
            return cargosDTO;
        }

        public List<DepartamentoDTO> ListarDepartamentos()
        {
            var departamentosDTO = new List<DepartamentoDTO>();
            using (var repositorio = new RepositorioBase<DepartamentoEntity>())
            {
                var departamentos = repositorio.Select().ToList();
                departamentosDTO = Mapper.Map<List<DepartamentoEntity>, List<DepartamentoDTO>>(departamentos);
            }
            return departamentosDTO;
        }

        public List<FuncionarioDTO> ListarSupervisores()
        {
            var supervisoresDTO = new List<FuncionarioDTO>();
            string[] includes = new string[] { "Cargo" };
            Expression<Func<FuncionarioEntity, bool>> expressionFiltro1 = (c => c.Cargo.DescricaoCargo.Contains("Supervisor"));

            using (var repositorio = new RepositorioBase<FuncionarioEntity>())
            {
                var supervisores = repositorio.Select(expressionFiltro1).ToList();
                supervisoresDTO = Mapper.Map<List<FuncionarioEntity>, List<FuncionarioDTO>>(supervisores);
            }
            return supervisoresDTO;
        }
    }
}
