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
    [Authorize]
    public class ClientController : ApiController
    {
        public object UserList(int pageSize, int pageNum)
        {
            Tuple<List<Client>, int> ret = ClientBLL.GetClient(OnlineUser.User.ID, pageSize, pageNum);
            return new { Result = ret.Item1, TotalAmount = ret.Item2 };
        }

        public object SearchClient(int pageSize, int pageNum, string key)
        {
            Tuple<List<Client>, int> ret = ClientBLL.SearchClient(OnlineUser.User.ID, pageSize, pageNum, key);
            return new { Result = ret.Item1, TotalAmount = ret.Item2 };
        }


        public object AddClient([FromBody]Client client)
        {
            if (ClientBLL.CheckIsDuplicate(Guid.Empty, client.ClientIdentity))
            {
                return new { Success = false, Duplicated = true };
            }
            ClientBLL.CreateClient(client);
            return new { Success = true };
        }

        public object UpdateClient([FromBody]Client client)
        {
            if (ClientBLL.CheckIsDuplicate(client.ID, client.ClientIdentity))
            {
                return new { Success = false, Duplicated = true };
            }
            ClientBLL.UpdateClient(client);
            return new { Success = true };
        }

        public object RemoveClient(Guid id)
        {
            ClientBLL.DeleteClient(id, OnlineUser.User.ID);
            return new { Success = true };
        }
    }
}