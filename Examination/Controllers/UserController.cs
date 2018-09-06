﻿using Exam.BLL;
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
        public object ChangePassword(string pwd)
        {
            UserBLL.UpdatePassword(OnlineUser.User.ID, pwd);
            return new { Result = true };
        }

        public object AddAdvice(string advice)
        {
            UserBLL.AddUserAdvice(OnlineUser.User.ID, advice);
            return new { Result = true };
        }
    }
}