using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core.Impl
{
    public interface IshowCastRepository
    {
       
        IEnumerable<ShowCast> GetAllShows();
        ShowCast getShowCastByID(int id);
        long AddShowsCast(ShowCast b);

        ShowCast getShowCastByShowsid(int Showsid);

        Task<long> SaveShowsCastAsync(List<ShowCast> myList);
    }
}
