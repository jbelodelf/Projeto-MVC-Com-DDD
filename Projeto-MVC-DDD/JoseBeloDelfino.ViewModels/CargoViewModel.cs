using System.ComponentModel;

namespace JoseBeloDelfino.ViewModels
{
    public class CargoViewModel
    {
        public int IdCargo { get; set; }
        [DisplayName("Cargo")]
        public string DescricaoCargo { get; set; }
    }
}
