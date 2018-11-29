using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Core;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IRestAPICall _restAPICall;
        private readonly IShowsRepository _showsRepository;
        public ShowsController(IRestAPICall restAPICall, IShowsRepository showsRepository)
        {
            _restAPICall = restAPICall;
            _showsRepository = showsRepository;
        }
        

        [HttpGet("{showsperPage}/{currentpage}", Name = "GetShows")]
        public ShowsPager GetShows(int showsperPage, int currentpage)
        {
            int skip = currentpage * showsperPage;
            var showCount = _showsRepository.ShowsCount();
            var pageCnt = showCount / showsperPage;
            var tvshow = _showsRepository.GetAllShows(skip, showsperPage);
            return new ShowsPager() { shows = tvshow, PageNumber = currentpage, CurrentPage = pageCnt };
        }


         

    }
}