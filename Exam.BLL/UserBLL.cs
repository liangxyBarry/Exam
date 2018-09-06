using Exam.Model;
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
                var user = ctx.Users.FirstOrDefault(u => u.ID == userId);
                if (user != null)
                {
                    user.Password = newPwd;
                }
            }
        }

        public static void AddUserAdvice(Guid userId, string userAdvice)
        {
            using (var ctx = new ExaminationEntities())
            {
                var advice = new Advice();
                advice.ID = Guid.NewGuid();
                advice.UserID = userId;
                advice.Advice1 = userAdvice;
                ctx.Advice.Add(advice);
                ctx.SaveChanges();
            }
        }
    }
}
