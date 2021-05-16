using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Lists
    {
        public Lists()
        {
            AssignedList = new HashSet<AssignedList>();
        }

        public int ListId { get; set; }
        public DateTime? Date { get; set; }
        public int? ClientId { get; set; }
        public int Id { get; set; }

        public virtual Clients Client { get; set; }
        public virtual ICollection<AssignedList> AssignedList { get; set; }
    }
}
