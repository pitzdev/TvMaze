using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class ShowCast
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int Castid { get; set; }
        public string name { get; set; }
        public DateTime? birthday { get; set; }
        public int Showsid { get; set; }
      // public virtual Shows shows   { get; set; }

    }

    class viewModel
    {
        public int ShowId { get; set; }
        public string showname { get; set; }
        public List<ShowCast> showscasts { get; set; }
        public int PageNumber { get; set; }
        public int PageCount { get; set; }
    }
}
