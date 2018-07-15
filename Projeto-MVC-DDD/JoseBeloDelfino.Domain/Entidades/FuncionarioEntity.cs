using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseBeloDelfino.Domain.Entidades
{
    [Table("TbFuncionario")]
    public class FuncionarioEntity
    {
        [Key]
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int IdSupervisor { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }

        public virtual DepartamentoEntity Departamento { get; set; }
        public virtual CargoEntity Cargo { get; set; }
    }
}
