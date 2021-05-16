using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class FoodTypes
    {
        public FoodTypes()
        {
            Foods = new HashSet<Foods>();
        }

        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }

        public virtual ICollection<Foods> Foods { get; set; }
    }
}
