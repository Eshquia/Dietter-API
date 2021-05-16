using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
  public interface IDietService
    {
        public List<FoodDto> GetFoods();
        public Foods GetFood(int id);
        public bool PostFood(FoodDto food);
        public bool DeleteFood(int id);
        public bool PutFood(FoodDto food);
    }
}
