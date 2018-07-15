using System.Collections.Generic;
using System.Web.Mvc;

namespace JoseBeloDelfino.DTOs
{
    public class FuncionarioDTO
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
        public List<SelectListItem> ComboCargo { get; set; }
        public List<SelectListItem> ComboDepartamento { get; set; }
        public List<SelectListItem> ComboSupervisor { get; set; }

        public DepartamentoDTO Departamento { get; set; }
        public CargoDTO Cargo { get; set; }

        public FuncionarioDTO()
        {
            ComboCargo = new List<SelectListItem>();
            ComboDepartamento = new List<SelectListItem>();
            ComboSupervisor = new List<SelectListItem>();
        }
    }
}
