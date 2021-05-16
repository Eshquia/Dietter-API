using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Classes.ListDataAccesLayer
{
    public class ListDataAccessLayer : IListDataAccessLayer
    {
        private DietterContext db = new DietterContext();
        public bool DeleteList(int id)
        {
            var a = db.Lists.First(x => x.Id == id);
            db.Lists.Remove(a);
            db.SaveChanges();
            return true;
        }

        public ListDto GetList(int id)
        {
            var lists = (from list in db.Lists
                         join client in db.Clients on list.ClientId equals client.ClientId
                         select new ListDto { ListId = list.ListId, ClientName = client.ClientName, Date = list.Date, Id = list.Id }
                                 ).FirstOrDefault(x=>x.Id==id); ;
            
            return lists;
        }

        public List<ListDto> GetLists()
        {
            var lists = (from list in db.Lists
                        join client in db.Clients on list.ClientId equals client.ClientId
                         select new ListDto { ListId = list.ListId, ClientName =client.ClientName, Date = list.Date,Id=list.Id }
                      ).ToList();
            return lists;
        }

        public bool PostList(ListDto list)
        {
            var newList = new Lists();
            newList.ClientId = list.ClientId;
            newList.Date =list.Date;
            newList.Id = list.Id;
            newList.ListId = list.ListId;
            db.Lists.Add(newList);
            db.SaveChanges();
            return true;
        }
    }
}
