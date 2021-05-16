using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AssignedList
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public int? ClientId { get; set; }
        public int FoodId { get; set; }
        public int Date { get; set; }

        public virtual Foods Food { get; set; }
        public virtual Lists List { get; set; }
    }
}
