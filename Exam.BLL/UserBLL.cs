﻿using Exam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL
{
    public class UserBLL
    {
        public static Users GetUserInfo(string userName, string pwd)
        {
            using (var ctx = new ExaminationEntities())
            {
                return ctx.Users.FirstOrDefault(u => u.UserName.ToLower() == (userName??"").ToLower() && u.Password == pwd);
            }
        }

        public static void UpdatePassword(Guid userId, string newPwd)
        {
              using (var ctx = new ExaminationEntities())
            {
                var user = ctx.Users.FirstOrDefault(u => u.ID== userId);
                if (user != null)
                {
                    user.Password = newPwd;
                }
            }
        }
    }
}
