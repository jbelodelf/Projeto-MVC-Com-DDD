using JoseBeloDelfino.Data.Contexto;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace JoseBeloDelfino.WebApi
{
    public class AuthorizationServerProvaider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origen", new[] { "*" });

            try
            {
                var user = context.UserName;
                var password = context.Password;

                using (var Base = new JoseBeloDelfinoDbContexto())
                {
                    var resultado = Base.Login.Where(a => a.LoginFuncionario == user && a.SenhaHash == password).FirstOrDefaultAsync();
                    if (resultado.Result == null)
                    {
                        context.SetError("invalid_grant", "Usuário ou senha inválidos");
                        return;
                    }
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user));

                var roles = new List<string>();
                roles.Add("Admin");
                roles.Add("User");

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception ex)
            {
                context.SetError("invalid-grant", "Falha ao autenticar");
            }
        }
    }
}