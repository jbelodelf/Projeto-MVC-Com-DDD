using AutoMapper;
using JoseBeloDelfino.WebApi.App_Start;
using System.Web.Http;
using System.Web.Mvc;

namespace JoseBeloDelfino.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mapper.Initialize(x => x.AddProfile(new AutoMapperConfig()));
        }
    }
}
