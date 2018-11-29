using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core
{
    public interface IRestAPICall
    {
        void getTvShows();
        void getShowCast();
        void getShowsCastByShowID(int id);
        Task LoadShowCast();
        Task LoadShowsAsync();
        void getShowCastPerShow();
    }
}
