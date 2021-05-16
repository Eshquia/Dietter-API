using DataAccess.DataCast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.ListService
{
   public interface IListService
    {
        public List<ListDto> GetLists();
        public ListDto GetList(int id);
        public bool PostList(ListDto list);
        public bool DeleteList(int id);
    }
}
