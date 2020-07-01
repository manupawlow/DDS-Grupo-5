using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;
using System.Linq;
using System.Threading.Tasks;

namespace TP_ANUAL_DDS.Egresos
{
    class Scheduler
    {
        private static Scheduler instance = new Scheduler();
        private static StdSchedulerFactory factory;
        private static IScheduler scheduler;


        public static Scheduler getInstance()
        {
            Scheduler.doInstance();
            return Scheduler.instance;
        }
        private static async void doInstance()
        {

            if (instance != null)
            {
                factory = new StdSchedulerFactory();
                scheduler = await factory.GetScheduler();
            }

        }
        public async void run()
        {
            await scheduler.Start();
        }

        public async void stop()
        {
            await scheduler.Shutdown();
        }

        public void agregarTarea(IJobDetail job, ITrigger trigger)
        {
            scheduler.ScheduleJob(job, trigger);
        }

    }
}
