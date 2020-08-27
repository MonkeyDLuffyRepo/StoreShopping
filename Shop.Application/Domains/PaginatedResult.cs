using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Domains
{
    public class PaginatedResult<T>
    {
        public int Total { get; set; }
        public List<T> Result { get; set; }
    }
}
