using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using MyHomeOrg.Common.Interfaces.Services.User;
using MyHomeOrg.WebApi.Providers;
using Owin;

[assembly: OwinStartup(typeof(MyHomeOrg.WebApi.Startup))]

namespace MyHomeOrg.WebApi
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // Configure the db context and user manager to use a single instance per request
            PublicClientId = "MyHomeOrg";
            app.UseCors(CorsOptions.AllowAll);
            var accountService = (IAccountService)GlobalConfiguration.Configuration.DependencyResolver.BeginScope()
                .GetService(typeof(IAccountService));

            // Configure the application for OAuth based flow
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId, accountService),

                AuthorizeEndpointPath = new PathString("/api/account/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Token Generation
            app.UseOAuthBearerTokens(OAuthOptions);

        }
    }
}
