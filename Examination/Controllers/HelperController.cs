using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Examination.Controllers
{
    public class HelperController : Controller
    {
        // GET: Helper
        public string Index()
        {
            StringBuilder ret = new StringBuilder();
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetAssembly(this.GetType());
            Type[] types = ass.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(ApiController)))
                {
                    var methods = type.GetMethods(BindingFlags.DeclaredOnly |
                 BindingFlags.Public | BindingFlags.NonPublic |
                 BindingFlags.Instance | BindingFlags.CreateInstance);
                    foreach (var method in methods)
                    {
                        ret.AppendFormat("<br/>Api Name:/api/{0}/{1}",type.Name.Replace("Controller",""), method.Name);
                        ret.AppendFormat("<br/>Parameters:");
                        foreach (var param in method.GetParameters())
                        {
                            ret.AppendFormat("<br/>&nbsp;&nbsp;&nbsp;&nbsp;{0}：{1}",param.Name, param.ParameterType.Name);
                        }
                    }
                    ret.Append("<br/>");
                }
 
            }
            return ret.ToString();
        }
    }
}