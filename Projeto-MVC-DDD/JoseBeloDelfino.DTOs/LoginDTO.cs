
namespace JoseBeloDelfino.DTOs
{
    public class LoginDTO
    {
        public int IdLogin { get; set; }
        public int IdFuncionario { get; set; }
        public string LoginFuncionario { get; set; }
        public string SenhaHash { get; set; }

        public FuncionarioDTO Funcionario { get; set; }
    }
}
