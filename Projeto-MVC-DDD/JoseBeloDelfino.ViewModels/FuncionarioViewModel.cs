using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace JoseBeloDelfino.ViewModels
{
    public class FuncionarioViewModel
    {
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
        [DisplayName("Cargo")]
        public List<SelectListItem> ComboCargo { get; set; }
        [DisplayName("Departamento")]
        public List<SelectListItem> ComboDepartamento { get; set; }
        [DisplayName("Supervisor")]
        public List<SelectListItem> ComboSupervisor { get; set; }

        public DepartamentoViewModel Departamento { get; set; }
        public CargoViewModel Cargo { get; set; }

        public FuncionarioViewModel()
        {
            ComboCargo = new List<SelectListItem>();
            ComboDepartamento = new List<SelectListItem>();
            ComboSupervisor = new List<SelectListItem>();
        }
    }
}