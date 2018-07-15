using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseBeloDelfino.Domain.Entidades
{
    [Table("TbLogin")]
    public class LoginEntity
    {
        [Key]
        public int IdLogin { get; set; }
        public int IdFuncionario { get; set; }
        public string LoginFuncionario { get; set; }
        public string SenhaHash { get; set; }

        public FuncionarioEntity Funcionario { get; set; }
    }
}
