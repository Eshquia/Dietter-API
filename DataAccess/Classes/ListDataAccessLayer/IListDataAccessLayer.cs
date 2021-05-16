using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Classes.ListDataAccesLayer
{
   public interface IListDataAccessLayer
    {
        public List<ListDto> GetLists();
        public ListDto GetList(int id);
        public bool PostList(ListDto list);
        public bool DeleteList(int id);
    }
}
