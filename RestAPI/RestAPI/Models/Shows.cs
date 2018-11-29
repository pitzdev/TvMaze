using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Shows
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int ShowId { get; set; }
        public string name { get; set; }
        public virtual ICollection<ShowCast> showCasts { get; set; }
    }
}
