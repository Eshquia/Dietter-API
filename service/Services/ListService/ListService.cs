using DataAccess.Classes.ListDataAccesLayer;
using DataAccess.DataCast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services.ListService
{
    public class ListService : IListService
    {
        private readonly IListDataAccessLayer _service;

        public ListService(IListDataAccessLayer service)
        {
            _service = service;
        }
        public List<ListDto> GetLists()
        {
            return _service.GetLists();
        }
        public ListDto GetList(int id)
        {
            return _service.GetList(id);
        }
        public bool PostList(ListDto list)
        {
            return _service.PostList(list);
        }
        public bool DeleteList(int id)
        {
            return _service.DeleteList(id);
        }
    }
}
