using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Lists = new HashSet<Lists>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Lists> Lists { get; set; }
    }
}
