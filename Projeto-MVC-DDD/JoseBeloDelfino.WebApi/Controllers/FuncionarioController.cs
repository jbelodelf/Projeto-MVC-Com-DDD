using JoseBeloDelfino.DTOs;
using JoseBeloDelfino.WebApi.Negocio.Interfaces;
using JoseBeloDelfino.WebApi.Negocio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JoseBeloDelfino.WebApi.Controllers
{
  [Authorize]
  public class FuncionarioController : ApiController
    {
        private IFuncionarioNegocio _funcionarioNegcio = new FuncionarioNegocio();

        [HttpGet]
        [Route("servicos/funcionario/ListarFuncionarios/{nome}")]
        public HttpResponseMessage ListarFuncionarios(string nome = null)
        {
            if (nome == "null") { nome = ""; }
            try
            {
                List<FuncionarioDTO> retorno = _funcionarioNegcio.ListarFuncionarios(nome).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, retorno, "application/json");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Erro", "application/json");
            }
        }

        [HttpGet]
        [Route("servicos/funcionario/obterFuncionario/{id:int}")]
        public HttpResponseMessage ObterFuncionario(int id)
        {
            try
            {
                FuncionarioDTO retorno = _funcionarioNegcio.ObterFuncionario(id);

                return Request.CreateResponse(HttpStatusCode.OK, retorno, "application/json");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Erro", "application/json");
            }
        }

        [HttpPost]
        [Route("servicos/funcionario/salvarFuncionarios")]
        public HttpResponseMessage SalvarFuncionarios(FuncionarioDTO funcionario)
        {
            try
            {
                FuncionarioDTO retorno = _funcionarioNegcio.SalvarFuncionario(funcionario);

                return Request.CreateResponse(HttpStatusCode.OK, retorno, "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Erro", "application/json");
            }
        }

        [HttpGet]
        [Route("servicos/funcionario/DeleteFuncionario/{id:int}")]
        public HttpResponseMessage DeleteFuncionario(int id)
        {
            try
            {
                _funcionarioNegcio.DeleteFuncionario(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Registro excluido com sucesso", "application/json");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Erro", "application/json");
            }
        }

    }
}
