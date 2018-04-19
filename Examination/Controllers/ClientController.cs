﻿using Exam.BLL;
using Exam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Examination.Controllers
{
    public class ClientController : ApiController
    {
        public object UserList(int pageSize, int pageNum)
        {
            var clientList = ClientBLL.GetClient(OnlineUser.User.ID, pageSize, pageNum);
            return clientList;
        }

        public object SearchClient(int pageSize, int pageNum, string key)
        {
            var clientList = ClientBLL.SearchClient(OnlineUser.User.ID, pageSize, pageNum, key);
            return clientList;
        }


        public object AddClient(string clientJson)
        {
            var client = JsonConvert.DeserializeObject<Client>(clientJson);
            ClientBLL.CreateClient(client);
            return new { Success = true };
        }

        public object UpdateClient(string clientJson)
        {
            var client = JsonConvert.DeserializeObject<Client>(clientJson);
            ClientBLL.UpdateClient(client);
            return new { Success = true };
        }
    }
}