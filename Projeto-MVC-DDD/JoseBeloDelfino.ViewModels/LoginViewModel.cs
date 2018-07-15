
namespace JoseBeloDelfino.ViewModels
{
    public class LoginViewModel
    {
        public int IdLogin { get; set; }
        public int IdFuncionario { get; set; }
        public string LoginFuncionario { get; set; }
        public string SenhaHash { get; set; }

        public FuncionarioViewModel Usuario { get; set; }
    }
}