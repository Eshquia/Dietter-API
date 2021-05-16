using service;
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.DataCast;
using DataAccess.Classes;

namespace Service
{
    public class DietService : IDietService
    {

        private readonly IFoodDataAccessLayer _service;

        public DietService(IFoodDataAccessLayer service)
        {
            _service = service;
        }

        public List<FoodDto> GetFoods()
        {
            return _service.GetFoods();
        }


        public Foods GetFood(int id)
        {
            return _service.GetFood(id);
        }
        public bool PostFood(FoodDto food)
        {
            return _service.PostFood(food);
        }

        public bool DeleteFood(int id)
        {
            return _service.DeleteFood(id);
        }

        public bool PutFood(FoodDto food)
        {
            return _service.PutFood(food);
        }
    }
}
