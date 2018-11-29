using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core.Impl
{
    public class ScheduledJob : IJob
    { 
         private  IRestAPICall _restAPICall;
        public ScheduledJob(IRestAPICall restAPICall)
        {
            
            this._restAPICall = restAPICall;
        }

        public   Task Execute(IJobExecutionContext context)
        {
            //this.ilogger.LogWarning($"Scheduled task Start :  {DateTime.Now.ToLongTimeString()}");
 
            return Task.Run(() =>
            {
                _restAPICall.getTvShows();
                _restAPICall.getShowCastPerShow();
            });
        }

         
    }
}
