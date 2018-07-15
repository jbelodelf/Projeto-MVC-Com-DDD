using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoseBeloDelfino.Domain.Entidades
{
    [Table("TbCargo")]
    public class CargoEntity
    {
        [Key]
        public int IdCargo { get; set; }
        public string DescricaoCargo { get; set; }
    }
}
