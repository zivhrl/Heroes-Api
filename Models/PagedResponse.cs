using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int MaxPages { get; set; }
    }
}
