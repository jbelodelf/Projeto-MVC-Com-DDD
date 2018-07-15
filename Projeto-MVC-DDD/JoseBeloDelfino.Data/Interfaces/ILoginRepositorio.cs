using JoseBeloDelfino.DTOs;

namespace JoseBeloDelfino.Data.Interfaces
{
    public interface ILoginRepositorio
    {
        LoginDTO ObterLogin(string login, string senha);
    }
}
