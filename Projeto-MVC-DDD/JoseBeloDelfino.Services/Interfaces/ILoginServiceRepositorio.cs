using JoseBeloDelfino.ViewModels;

namespace JoseBeloDelfino.Services.Interfaces
{
    public interface ILoginServiceRepositorio
    {
        LoginViewModel ObterLogin(string login, string senha);
    }
}
