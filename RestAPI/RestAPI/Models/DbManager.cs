using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class DbManager : DbContext 
    { 

        public DbManager(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<Shows> Shows { get; set; }
        public DbSet<ShowCast> ShowCast { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


    }
}
