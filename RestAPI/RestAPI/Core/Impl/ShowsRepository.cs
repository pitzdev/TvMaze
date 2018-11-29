using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core
{
    public class ShowsRepository : IShowsRepository
    {
        DbManager ctx;

        public ShowsRepository(DbManager dbManager)
        {
            ctx = dbManager;
        }
        

        public long AddShows(Shows b)
        {
            long id = 0;
            try
            {
               
                var show = ctx.Shows.FirstOrDefault(x => x.ShowId == b.ShowId);
                if (show == null)
                {
                    ctx.Shows.Add(b);
                    id = ctx.SaveChanges();
                }
                else
                {
                    ctx.Shows.Update(b);
                    ctx.SaveChanges();
                }
                    
            }
            catch (Exception ex)
            {

                 
            }
            

            return id;
        }

        public IEnumerable<Shows> FindAllShows()
        {

            return ctx.Shows;
        }

        public IEnumerable<Shows> GetAllShows(int skip, int pick)
        {

            var tvshows = ctx.Shows.Skip(skip).Take(pick).Include(d => d.showCasts);
            foreach (var ts in tvshows)
            {
                ts.showCasts = ts.showCasts.OrderByDescending(b => b.birthday).ToList();
            }
            return tvshows;
             
        }

        public Shows getShowByID(int id)
        {
            return ctx.Shows.FirstOrDefault(x => x.id == id);
        }

        public List<Shows> getShowsList()
        {
            return ctx.Shows.ToList();
        }

        public async Task<long> SaveShowsAsync(List<Shows> myList)
        {
            long id = 0;
            try
            {
                    ctx.Shows.AddRange(myList); 
                    await ctx.SaveChangesAsync();
                    // ctx.AddRangeAsync.
                    //id = ctx.SaveChanges();
                
            }
            catch (Exception)
            {

                
            }
            return id;
        }

        public int ShowsCount()
        {
            return ctx.Shows.Count();
        }
    }
}
