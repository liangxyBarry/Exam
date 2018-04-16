using Exam.BLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
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
            LogHelper.SystemError("Application_Error", Server.GetLastError());
        }
    }
}
