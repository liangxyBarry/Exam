using Exam.BLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Examination
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            SetGlobalVars();
        }

        private void SetGlobalVars()
        {
            GlobalVars.SettingDir = Server.MapPath("~/Settings");
        }

        protected void Application_Error()
        {
            string url = Request.Url.ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append(url+"\n");
            foreach (var param in Request.Params)
            {
                sb.AppendFormat("{0}:{1}\n",param, Request.Params[param.ToString()]);
            }
            LogHelper.SystemError("Application_Error"+ sb.ToString(), Server.GetLastError());
        }
    }
}
