using Exam.BLL.Helper;
using Exam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL
{
    public class ClientBLL
    {
        public static List<Client> GetClient(Guid userId, int pageSize, int pageNum)
        {
            using (var ctx = new ExaminationEntities())
            {
                return ctx.Client.Where(c => c.UserID == userId).OrderBy(c => c.Name).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            }
        }

        public static List<Client> SearchClient(Guid userId, int pageSize, int pageNum,  string key)
        {
            using (var ctx = new ExaminationEntities())
            {
                return ctx.Client.Where(c => c.UserID == userId &&
                (
                (c.Name??"").IndexOf(key, StringComparison.CurrentCultureIgnoreCase)>=0
                || (c.ClientIdentity??"").IndexOf(key, StringComparison.CurrentCultureIgnoreCase) >= 0
                )).OrderBy(c => c.Name).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
            }
        }

        public static void CreateClient(Client client)
        {
            client.ID = Guid.NewGuid();
            client.UserID = OnlineUser.User.ID;
            using(var ctx = new ExaminationEntities())
            {
                ctx.Client.Add(client);
                ctx.SaveChanges();
            }
        }

        public static void UpdateClient(Client client)
        {
            using (var ctx = new ExaminationEntities())
            {
                var dbClient = ctx.Client.FirstOrDefault(c => c.UserID == OnlineUser.User.ID && client.ID == client.ID);
                Utility.SetObjectValueWithSamePropName(client, dbClient);
                ctx.SaveChanges();
            }
        }
    }
}
