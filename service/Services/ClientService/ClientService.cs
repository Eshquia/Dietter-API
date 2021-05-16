using DataAccess.Classes.ClientDataAccesLayer;
using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.ClientService
{
    public class ClientService : IClientService
    {
        /// <summary>DoWork is a method in the TestClass class.
        /// Bu katmanı data accese erişimden sonra ihtiyac duyarım diye yazdım. fakata ihtiyaç olmadı. 
        /// </summary>
        private readonly IClientDataAccessLayer _service;
        public ClientService(IClientDataAccessLayer service)
        {
            _service = service;
        }

        public List<List<DietList>> CreateDiet(Diet diet)
        {
            return _service.CreateDiet(diet);
        }

        public bool DeleteClient(int id)
        {
            return _service.DeleteClient(id);
        }

        public ClientDto GetClient(int id)
        {
            return _service.GetClient(id);
        }

        public List<ClientDto> GetClientList()
        {
            return _service.GetClientList();
        }

        public bool PostClient(ClientDto client)
        {
            return _service.PostClient(client);
        }

        public bool PutClient(ClientDto client)
        {
            return _service.PutClient(client);
        }


    }
}
