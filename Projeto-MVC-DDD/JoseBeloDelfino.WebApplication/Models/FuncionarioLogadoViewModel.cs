using JoseBeloDelfino.ViewModels;
using System;

namespace JoseBeloDelfino.WebApplication.Models
{
    public class FuncionarioLogadoViewModel
    {
        public int IdLogin { get; set; }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public bool Logado { get; set; }
        public DateTime DataAcesso { get; set; }

        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        
        public void AtualizaUsuarioLogado(LoginViewModel login)
        {
            Usuario.Logado = new FuncionarioLogadoViewModel();
            Usuario.Logado.IdLogin = login.IdLogin;
            Usuario.Logado.IdFuncionario = login.Usuario.IdFuncionario;
            Usuario.Logado.Nome = login.Usuario.Nome;
            Usuario.Logado.Logado = true;
            Usuario.Logado.DataAcesso = DateTime.Now;
            Usuario.Logado.UserName = login.Usuario.Nome;
        }
    }

    public static class Usuario
    {
        public static FuncionarioLogadoViewModel Logado { get; set; }
    }
}