﻿using Exam.BLL.Helper;
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
        public static Tuple<List<Client>,int> GetClient(Guid userId, int pageSize, int pageNum)
        {
            using (var ctx = new ExaminationEntities())
            {
                var list = ctx.Client.Where(c => c.UserID == userId).OrderByDescending(c => c.CreatedDate);
                int amt = list.Count();
                var retList= list.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                return new Tuple<List<Client>, int>(retList, amt);
            }
        }

        public static Tuple<List<Client>,int> SearchClient(Guid userId, int pageSize, int pageNum,  string key)
        {
            using (var ctx = new ExaminationEntities())
            {
                var list = ctx.Client.Where(c => c.UserID == userId &&
                 (
                 (c.Name ?? "").ToLower().Contains(key.ToLower())
                 || (c.ClientIdentity ?? "").ToLower().Contains(key.ToLower())
                 )).OrderBy(c => c.Name);
                int amt = list.Count();
                var retList=list.Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                return new Tuple<List<Client>, int>(retList, amt);
            }
        }

        public static bool CheckIsDuplicate(Guid id, string identity)
        {
            using (var ctx = new ExaminationEntities())
            {
                var exist = ctx.Client.FirstOrDefault(c =>  id != c.ID && identity.Trim() == c.ClientIdentity.Trim());
                return exist != null;
            }

        }

        public static void CreateClient(Client client)
        {
            client.ID = Guid.NewGuid();
            client.UserID = OnlineUser.User.ID;
            client.CreatedDate = DateTime.Now;
            using(var ctx = new ExaminationEntities())
            {
                ctx.Client.Add(client);
                ctx.SaveChanges();
            }
        }

        public static void DeleteClient(Guid id, Guid userId)
        {
            using (var ctx = new ExaminationEntities())
            {
                var exist = ctx.Client.FirstOrDefault(c => id == c.ID && c.UserID == userId);
                ctx.Client.Remove(exist);
                ctx.SaveChanges();
            }
        }


        public static void UpdateClient(Client client)
        {
            using (var ctx = new ExaminationEntities())
            {
                var dbClient = ctx.Client.FirstOrDefault(c => c.UserID == OnlineUser.User.ID && c.ID == client.ID);

                Utility.SetObjectValueWithSamePropName(client, dbClient, new List<string>() { "ID", "UserID", "CreatedDate" });
                ctx.SaveChanges();
            }
        }
    }
}
