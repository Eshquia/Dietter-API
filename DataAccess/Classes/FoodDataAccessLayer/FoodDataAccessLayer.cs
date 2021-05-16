using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using DataAccess.Classes;

namespace DataAccess
{
    public class FoodDataAccessLayer: IFoodDataAccessLayer
    {

        private DietterContext db = new DietterContext();

        public List<FoodDto> GetFoods()
        {
            var list = (from food in db.Foods
                        join foodtype in db.FoodTypes on food.FoodType equals foodtype.FoodTypeId
                        select new FoodDto { FoodTypeName = foodtype.FoodTypeName.Trim(), FoodName = food.FoodName.Trim(),Calorie=food.Calorie,FoodType=food.FoodType,Id=food.Id }
           ).ToList();
            return list;
        }
        public Foods GetFood(int id)
        {
            var FoodList = db.Foods.FirstOrDefault(x => x.Id == id);
            return FoodList;
        }

        public bool PostFood(FoodDto food)
        {

                var newFood = new Foods();
                newFood.Calorie = food.Calorie;
                newFood.FoodName = food.FoodName;
                newFood.FoodType = food.FoodType;
                db.Foods.Add(newFood);
                db.SaveChanges();
                return true;
        }

        public bool DeleteFood(int id)
        {

                var a = db.Foods.First(x => x.Id == id);
                db.Foods.Remove(a);
                db.SaveChanges();
                return true;

        }

        public bool PutFood(FoodDto food)
        {
            var result = db.Foods.First(x => x.Id == food.Id);
            if (result == null)
            {
                return false;
            }
            result.Calorie = food.Calorie;
            result.FoodName = food.FoodName;
            result.FoodType = food.FoodType;
            db.Foods.Update(result);
            db.SaveChanges();
            return true;
        }


    }
}
