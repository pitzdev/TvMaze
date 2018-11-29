using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestAPI.Core.Impl;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RestAPI.Core
{
    public class RestAPICall : IRestAPICall
    {
        private readonly IShowsRepository _showsRepository;
        private readonly IshowCastRepository _ishowCastRepository;
        public RestAPICall (IShowsRepository repo, IshowCastRepository ishowCastRepository)
        {
            this._showsRepository = repo;
            this._ishowCastRepository = ishowCastRepository;
        }

        public void getTvShows()
        {
            int showid = 0; 
            var apiRes = jsonString("http://api.tvmaze.com/shows");
            var jsonres = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(apiRes);
         
            foreach (var obj in jsonres)
            {
                showid = int.Parse(obj["id"].ToString());
                var shows = new Shows
                {
                    name = obj["name"].ToString(),
                    ShowId = showid,
                };
              
                
                _showsRepository.AddShows(shows);
                
            }
           

            //async method  _showsRepository.AddShows(shows);
        }

        public void getShowCastPerShow()
        {
            var showlist = _showsRepository.FindAllShows();
            if (showlist != null)
            {
                foreach (var s in showlist)
                {
                    int id = s.ShowId;
                    var apiRes = jsonString("http://api.tvmaze.com/shows/" + id + "/cast");
                    JArray jsonResponse = JArray.Parse(apiRes);
                    string myId, myName, myBirthday, mygender;
                    
                    foreach (var item in jsonResponse)
                    {
                        myBirthday = myId = mygender = myName  = "";
                        var cnt = 0;
                        JObject jPerson = (JObject)item["person"];
                        foreach (var rItem in jPerson)
                        {
                            string rItemKey = rItem.Key;
                            string myVal = rItem.Value.ToString();
                            switch (rItemKey)
                            {
                                case "name":
                                    myName = rItem.Value.ToString();
                                    cnt++;
                                    break;
                                case "birthday":
                                    myBirthday = rItem.Value.ToString();
                                    cnt++;
                                    break;
                                case "id":
                                    myId = rItem.Value.ToString();
                                    cnt++;
                                    break;
                            }
                            if (cnt == 3)
                            {
                                break;
                            }

                        }
                        //do your save here 
                        DateTime? myDate = null;
                        DateTime outDate;
                        if (DateTime.TryParse(myBirthday, out outDate))
                        {
                            myDate = outDate;
                        }
                        var showsCast = new ShowCast
                        {
                            name = myName,
                            birthday = myDate,
                            Castid = int.Parse(myId),
                            Showsid = id
                        };
                        _ishowCastRepository.AddShowsCast(showsCast);
                    }
                    
                }

            }



        }
        public void  getShowsCastByShowID(int id)
        {
            
            var apiRes = jsonString("http://api.tvmaze.com/shows/"+ id + "/cast");
            JArray jsonResponse = JArray.Parse(apiRes);
            string myId, myName, myBirthday, mygender, myurl;
            var myList = new List<ShowCast>();
            foreach (var item in jsonResponse)
            {
                myBirthday = myId = mygender = myName = myurl = "";
                var cnt = 0;
                JObject jPerson = (JObject)item["person"];
                foreach (var rItem in jPerson)
                {
                    string rItemKey = rItem.Key;
                    string myVal = rItem.Value.ToString();
                    switch (rItemKey)
                    {
                        case "name":
                            myName= rItem.Value.ToString();
                            cnt++;
                            break;
                        case "birthday":
                           myBirthday= rItem.Value.ToString();
                            cnt++;
                            break;
                        case "id":
                            myId= rItem.Value.ToString();
                            cnt++;
                            break;
                    }
                    if (cnt == 3)
                    {
                        break;
                    }
                    
                }
                //do your save here 
                DateTime? myDate = null;
                DateTime outDate ;
                if (DateTime.TryParse(myBirthday, out outDate))
                {
                    myDate = outDate;
                }
                var showsCast = new ShowCast
                {
                    name = myName,
                    birthday = myDate,
                    Castid = int.Parse(myId),
                    Showsid = id
                };
                myList.Add(showsCast);
            }
            _ishowCastRepository.SaveShowsCastAsync(myList);
        }
         
        public string jsonString(string method)
        {

            string result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(method);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

           
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }

        public void getShowCast()
        {
            var showList = _showsRepository.FindAllShows();
            foreach(var k in showList)
            {
                var showcast = _ishowCastRepository.getShowCastByShowsid(k.id);
                if (showcast == null)
                {
                    getShowsCastByShowID(k.id);
                }
           
            }
        }

        public Task LoadShowsAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoadShowCast()
        {

            return Task.CompletedTask;
        }
    }
}
