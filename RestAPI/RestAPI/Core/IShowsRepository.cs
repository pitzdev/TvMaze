using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core
{
   public interface IShowsRepository
    {
        IEnumerable<Shows> GetAllShows(int skip, int pick);
        IEnumerable<Shows> FindAllShows();
        int ShowsCount();
        Shows getShowByID(int id);
        long AddShows(Shows b); 
    }
}
