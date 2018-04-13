using Exam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Exam.BLL
{
    public class OnlineUser
    {
        public static Users User
        {
            get
            {
                var claims = (ClaimsIdentity)HttpContext.Current.User.Identity;
                var claim = claims.FindFirst("userModel");
                if (claim != null)
                {
                    string json = claim.Value;
                    return JsonConvert.DeserializeObject<Users>(json);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
