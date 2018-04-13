using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Examination;
using Examination.App_Start;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(WebApi.Startup))]
namespace WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);

            //WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.Use(config);
            //GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AuthorizeEndpointPath = new PathString("/api/account/login"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            //    Provider = new ExamAuthProvider()
            //};
            //app.UseOAuthAuthorizationServer(OAuthServerOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ExamAuthProvider(),
                RefreshTokenProvider = new ExamRefreshTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(24),
                AuthenticationMode = AuthenticationMode.Active,
                AllowInsecureHttp = true,
            });
        }
    }
}
