using Exam.BLL;
using Exam.Model;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Examination.App_Start
{
    public class ExamAuthProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }


        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            string userName = context.UserName;
            string pwd = context.Password;
            Users user = UserBLL.GetUserInfo(userName,pwd);
            if (user != null && user.PIsLock!=1)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                identity.AddClaim(new Claim("userModel", JsonConvert.SerializeObject(user)));
                context.Validated(identity);
            }
            else if (user.PIsLock == 1)
            {
                context.SetError("locked","用户被锁定");
            }

        }
    }
}