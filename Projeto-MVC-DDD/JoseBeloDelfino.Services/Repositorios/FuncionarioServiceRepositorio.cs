using AutoMapper;
using JoseBeloDelfino.DTOs;
using JoseBeloDelfino.Services.Interfaces;
using JoseBeloDelfino.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace JoseBeloDelfino.Services.Repositorios
{
    public class FuncionarioServiceRepositorio : IFuncionarioServiceRepositorio
    {
        private void ConfigurarHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:21963/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public FuncionarioViewModel ObterFuncionario(int id, string token)
        {
            Retorno.WebApi = new ResponseWebApiViewModel();
            var funcionario = new FuncionarioDTO();
            try
            {
                string request = "servicos/funcionario/obterFuncionario";
                HttpResponseMessage response = null;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request = string.Format("{0}/{1}", request, id);
                    ConfigurarHttpClient(client);
                    response = client.GetAsync(request).Result;

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Retorno.WebApi.Status = response.StatusCode.ToString();
                        Retorno.WebApi.Message = response.ToString();
                        return null;
                    }

                    var retorno = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(retorno))
                        return null;

                    funcionario = JsonConvert.DeserializeObject<FuncionarioDTO>(retorno);
                }
                var funcionarioViewModel = Mapper.Map<FuncionarioDTO, FuncionarioViewModel>(funcionario);
                return funcionarioViewModel;
            }
            catch (Exception ex)
            {
                return new FuncionarioViewModel();
            }
        }

        public List<FuncionarioViewModel> ListarFuncionarios(string nome, string token)
        {
            var funcionarios = new List<FuncionarioDTO>();
            try
            {
                string request = "servicos/funcionario/ListarFuncionarios";
                if (nome == "")
                    nome = "null";
                
                request = string.Format("{0}/{1}", request, nome);

                HttpResponseMessage response = null;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    ConfigurarHttpClient(client);
                    response = client.GetAsync(request).Result;

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Retorno.WebApi.Status = response.StatusCode.ToString();
                        Retorno.WebApi.Message = response.ToString();
                        return null;
                    }

                    var retorno = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(retorno))
                        return null;

                    funcionarios = JsonConvert.DeserializeObject<List<FuncionarioDTO>>(retorno).ToList();
                }
                var funcionariosViewModel = Mapper.Map<List<FuncionarioDTO>, List<FuncionarioViewModel>>(funcionarios);
                return funcionariosViewModel;
            }
            catch (Exception ex)
            {
                return new List<FuncionarioViewModel>();
            }
        }

        public FuncionarioViewModel SalvarFuncionario(FuncionarioViewModel funcionario, string token)
        {
            var funcionarioDTO = new FuncionarioDTO();
            try
            {
                funcionarioDTO = Mapper.Map<FuncionarioViewModel, FuncionarioDTO>(funcionario);
                string request = "servicos/funcionario/salvarFuncionarios";
                HttpResponseMessage response = null;
                string funcionarioJSON = null;

                using (HttpClient client = new HttpClient())
                {
                    funcionarioJSON = JsonConvert.SerializeObject(funcionarioDTO);
                    StringContent conteudo = new StringContent(funcionarioJSON, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request = string.Format("{0}", request);
                    ConfigurarHttpClient(client);
                    response = client.PostAsync(request, conteudo).Result;

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Retorno.WebApi.Status = response.StatusCode.ToString();
                        Retorno.WebApi.Message = response.ToString();
                        return null;
                    }

                    var retorno = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(retorno))
                        return null;

                    funcionarioDTO = JsonConvert.DeserializeObject<FuncionarioDTO>(retorno);
                }
                var funcionariosViewModel = Mapper.Map<FuncionarioDTO, FuncionarioViewModel>(funcionarioDTO);
                return funcionariosViewModel;
            }
            catch (Exception ex)
            {
                return new FuncionarioViewModel();
            }
        }

        public string DeleteFuncionario(int id, string token)
        {
            Retorno.WebApi = new ResponseWebApiViewModel();
            string resultado = "";
            try
            {
                string request = "servicos/funcionario/DeleteFuncionario";
                HttpResponseMessage response = null;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request = string.Format("{0}/{1}", request, id);
                    ConfigurarHttpClient(client);
                    response = client.GetAsync(request).Result;

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        Retorno.WebApi.Status = response.StatusCode.ToString();
                        Retorno.WebApi.Message = response.ToString();
                        return null;
                    }

                    var retorno = response.Content.ReadAsStringAsync().Result;

                    if (String.IsNullOrEmpty(retorno))
                        return null;

                    resultado = JsonConvert.DeserializeObject<string>(retorno);
                }
                //var funcionarioViewModel = Mapper.Map<FuncionarioDTO, FuncionarioViewModel>(funcionario);
                return resultado;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
