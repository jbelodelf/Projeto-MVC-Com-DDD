using AutoMapper;
using JoseBeloDelfino.Data.Interfaces;
using JoseBeloDelfino.Domain.Entidades;
using JoseBeloDelfino.DTOs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JoseBeloDelfino.Data.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        public LoginDTO ObterLogin(string login, string senha)
        {
            LoginEntity usuario = null;
            string[] includes = new string[] { "Funcionario" };
            Expression<Func<LoginEntity, bool>> expressionFiltro = (a => a.LoginFuncionario == login && a.SenhaHash == senha);

            using (var repositorio = new RepositorioBase<LoginEntity>())
            {
                usuario = repositorio.Select(expressionFiltro, includes).FirstOrDefault();
            }

            var usuarioDTO = Mapper.Map<LoginEntity, LoginDTO>(usuario);
            return usuarioDTO;
        }
    }
}
