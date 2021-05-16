using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Classes.ClientDataAccesLayer
{
   public interface IClientDataAccessLayer
    {
        public List<ClientDto> GetClientList();
        public ClientDto GetClient(int id);
        public bool PostClient(ClientDto client);
        public bool PutClient(ClientDto client);
        public bool DeleteClient(int id);
        public List<List<DietList>> CreateDiet(Diet diet);
    }
}
