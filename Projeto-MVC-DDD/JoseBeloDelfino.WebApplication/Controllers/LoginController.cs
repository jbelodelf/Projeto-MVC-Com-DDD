using JoseBeloDelfino.Negocio.InterfacesApp;
using JoseBeloDelfino.ViewModels;
using JoseBeloDelfino.WebApplication.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace JoseBeloDelfino.WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private IFuncionarioNegocio _funcionarioNegocio;

        public LoginController(IFuncionarioNegocio funcionarioNegocio)
        {
            _funcionarioNegocio = funcionarioNegocio;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string Token)
        {
            var senhaHash = ConvertHash(loginViewModel.SenhaHash);
            return Json(new { Login = loginViewModel.LoginFuncionario, SenhaHash = senhaHash }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Usuario.Logado = null;
            return RedirectToAction("Login");
        }

        private string ConvertHash(string senha)
        {
            SHA256Managed hashstring = new SHA256Managed();
            byte[] bytes = Encoding.ASCII.GetBytes(Convert.ToString(senha));
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
        }

    }
}