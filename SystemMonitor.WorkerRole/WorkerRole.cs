using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.Diagnostics.Management;
using Ninject;

namespace SystemMonitor.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        internal static StandardKernel NinjectKernel;

        public override void Run()
        {
            Trace.WriteLine("SystemMonitor.WorkerRole entry point called", "Information");

            while (true)
            {
                Thread.Sleep(3000);
                Trace.WriteLine("Obtaining performance counter data from readers", "Information");

                NinjectKernel.GetAll<IPerformanceCounterReader>().ToList().ForEach(x => x.ReadValue());

                Trace.WriteLine("All performance counter readers polled.", "Information");
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            Trace.WriteLine("Wiring up Ninject Kernel", "Information");

            NinjectKernel = new StandardKernel();
            NinjectKernel.Bind<ITraceMessageWriter>().To<TraceMessageWriter>().InSingletonScope();
            NinjectKernel.Bind<IPerformanceCounterReader>().To<CpuPerformanceReader>().InSingletonScope();
            NinjectKernel.Bind<IPerformanceCounterReader>().To<MemoryPerformanceReader>().InSingletonScope();

            Trace.WriteLine("Ninject Kernel prepared", "Information");
            Trace.WriteLine("Starting up Hub server", "Information");

            new HubServer(NinjectKernel).Start();

            Trace.WriteLine("Hub Server started", "Information");

            return base.OnStart();
        }
    }
}
