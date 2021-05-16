using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataCast
{
 public class FoodDto
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int? FoodType { get; set; }
        public string? FoodTypeName { get; set; }
        public int? Calorie { get; set; }
    }
}
