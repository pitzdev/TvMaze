using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Core.Impl
{
    public class ScheduledJobFactory : IJobFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ScheduledJobFactory(IServiceProvider service)
        {
            this.serviceProvider = service;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            var disposable = job as IDisposable;
            if(disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
