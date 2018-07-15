using AutoMapper;
using JoseBeloDelfino.Data.Interfaces;
using JoseBeloDelfino.DTOs;
using JoseBeloDelfino.Services.Interfaces;
using JoseBeloDelfino.ViewModels;
using System;

namespace JoseBeloDelfino.Services.Repositorios
{
    public class LoginServiceRepositorio : ILoginServiceRepositorio
    {
        //private ILoginRepositorio _negocio;

        //public LoginServiceRepositorio(ILoginRepositorio negocio)
        //{
        //    _negocio = negocio;
        //}

        public LoginViewModel ObterLogin(string login, string senha)
        {

            //var loginDTO = _negocio.ObterLogin(login, senha);
            //var loginViewModel = Mapper.Map<LoginDTO, LoginViewModel>(loginDTO);
            //return loginViewModel;

            throw new NotImplementedException();
        }
    }
}
