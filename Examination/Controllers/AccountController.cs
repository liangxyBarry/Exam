using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Examination.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public void Login(string username, string password)
        {
            
        }
    }
}
