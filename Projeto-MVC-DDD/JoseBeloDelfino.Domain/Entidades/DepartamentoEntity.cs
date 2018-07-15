using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseBeloDelfino.Domain.Entidades
{
    [Table("TbDepartamento")]
    public class DepartamentoEntity
    {
        [Key]
        public int IdDepartamento { get; set; }
        public string NomeDepartamento { get; set; }
    }
}
