using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Foods
    {
        public Foods()
        {
            AssignedList = new HashSet<AssignedList>();
        }

        public int Id { get; set; }
        public string FoodName { get; set; }
        public int? FoodType { get; set; }
        public int? Calorie { get; set; }

        public virtual FoodTypes FoodTypeNavigation { get; set; }
        public virtual ICollection<AssignedList> AssignedList { get; set; }
    }
}
