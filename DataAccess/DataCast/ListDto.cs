using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataCast
{
  public class ListDto
    {
        public int ListId { get; set; }
        public DateTime? Date { get; set; }
        public int? ClientId { get; set; }
        public int Id { get; set; }
        public string ClientName { get; set; }
    }
}
