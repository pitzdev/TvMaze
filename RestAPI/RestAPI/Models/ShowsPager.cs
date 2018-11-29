using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class ShowsPager
    {
        public IEnumerable<Shows> shows { get; set; }      
        public int CurrentPage { get; set; }
        public int PageNumber { get; set; } 
    }
}
