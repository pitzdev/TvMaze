using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPI.Models;

namespace RestAPI.Core.Impl
{
    public class ShowCastRepository : IshowCastRepository
    {

        DbManager ctx;

        public ShowCastRepository(DbManager dbManager)
        {
            ctx = dbManager;
        }

        public long AddShowsCast(ShowCast b)
        {
            long id = 0;
            try
            {

                var show = ctx.ShowCast.FirstOrDefault(x => x.Castid == b.Castid && x.Showsid == b.Showsid);
                if (show == null)
                {
                    ctx.ShowCast.Add(b);
                    id = ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {


            }


            return id;
        }

        public IEnumerable<ShowCast> GetAllShows()
        {
            throw new NotImplementedException();
        }

        public ShowCast getShowCastByID(int id)
        {
            return ctx.ShowCast.Where(x => x.id == id).FirstOrDefault();
        }

        public ShowCast getShowCastByShowsid(int Showsid)
        {
            return ctx.ShowCast.Where(e => e.Showsid == Showsid).FirstOrDefault();
        }

        public async Task<long> SaveShowsCastAsync(List<ShowCast> myList)
        {
            long id = 0;
            try
            {
                ctx.ShowCast.AddRange(myList);
                await ctx.SaveChangesAsync();


            }
            catch (Exception ex)
            {


            }
            return id;
        }
    }
}
