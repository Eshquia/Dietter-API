using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataCast
{
  public  class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
