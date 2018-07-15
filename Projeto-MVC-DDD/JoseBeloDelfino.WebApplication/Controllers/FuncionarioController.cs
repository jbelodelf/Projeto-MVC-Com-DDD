using JoseBeloDelfino.Negocio.InterfacesApp;
using JoseBeloDelfino.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JoseBeloDelfino.WebApplication.Controllers
{
    public class FuncionarioController : Controller
    {
        private IFuncionarioNegocio _funcionarioNegocio;

        public FuncionarioController(IFuncionarioNegocio funcionarioNegocio)
        {
            _funcionarioNegocio = funcionarioNegocio;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarFuncionarios(string Token, string nome = "")
        {
            var listaFuncionarios = new List<FuncionarioViewModel>();
            listaFuncionarios = _funcionarioNegocio.ListarFuncionarios(nome, Token);
            if (Retorno.WebApi.Status == "Unauthorized")
                return Json(Retorno.WebApi.Status, JsonRequestBehavior.AllowGet);

            return PartialView("~/Views/Funcionario/_ListarFuncionarios.cshtml", listaFuncionarios);
        }

        public ActionResult Create(string Token, int Id = 0)
        {
            ViewBag.Title = "Cadastrar Funcionario";

            FuncionarioViewModel funcionario = new FuncionarioViewModel();
            funcionario = _funcionarioNegocio.ObterFuncionario(Id, Token);
            return View("~/Views/Funcionario/FormFuncionario.cshtml", funcionario);
        }

        [HttpGet]
        public ActionResult Edit(int Id, string Token)
        {
            ViewBag.Title = "Alterar Funcionario";

            var funcionario = _funcionarioNegocio.ObterFuncionario(Id, Token);
            if (Retorno.WebApi.Status == "Unauthorized")
                return Redirect("http://localhost:4485/");

            return View("~/Views/Funcionario/FormFuncionario.cshtml", funcionario);
        }

        [HttpGet]
        public ActionResult Delete(int Id, string Token)
        {
            var retorno = _funcionarioNegocio.DeleteFuncionario(Id, Token);
            if (Retorno.WebApi.Status == "Unauthorized")
                return Redirect("http://localhost:4485/");

            return Json(new { mensagem = retorno, retorno = Retorno.WebApi.Status }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Salvar(FuncionarioViewModel funcionario, string Token)
        {
            var retorno = _funcionarioNegocio.SalvarFuncionario(funcionario, Token);
            return Json(new { mensagem = "Registro gravado com sucesso!!!", retorno = Retorno.WebApi.Status }, JsonRequestBehavior.AllowGet);
        }
    }
}