using Exam.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Examination.Controllers
{
    public class UserController : ApiController
    {
        [Authorize]
        public object ChangePassword(string pwd, string oldpwd)
        {
            if (OnlineUser.User.Password == oldpwd)
            {
                UserBLL.UpdatePassword(OnlineUser.User.ID, pwd);
                OnlineUser.User.Password = pwd;
                return new { Result = true };
            }
            else
            {
                return new { Result = false, Message="原始密码不正确" };
            }
          
        }

        public object AddAdvice(string advice)
        {
            UserBLL.AddUserAdvice(OnlineUser.User.ID, advice);
            return new { Result = true };
        }
    }
}