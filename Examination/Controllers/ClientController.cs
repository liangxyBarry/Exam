using Exam.BLL;
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
        [HttpPost]
        public string UserList()
        {
            var clientList = ClientBLL.GetClient(OnlineUser.User.ID);
            return JsonConvert.SerializeObject(clientList);
        }

        [HttpPost]
        public string AddClient(string clientJson)
        {
            var client = JsonConvert.DeserializeObject<Client>(clientJson);
            ClientBLL.CreateClient(client);
            return JsonConvert.SerializeObject(new { Success = true });
        }

        [HttpPost]
        public string UpdateClient(string clientJson)
        {
            var client = JsonConvert.DeserializeObject<Client>(clientJson);
            ClientBLL.UpdateClient(client);
            return JsonConvert.SerializeObject(new { Success = true });
        }
    }
}