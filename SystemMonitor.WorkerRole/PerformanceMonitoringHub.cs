using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemMonitor.WorkerRole
{
    [HubName("performanceMonitor")]
    public class PerformanceMonitoringHub : Hub
    {
        private IEnumerable<IPerformanceCounterReader> _valueProvider;

        public PerformanceMonitoringHub(IEnumerable<IPerformanceCounterReader> valueProviders)
        {
            _valueProvider = valueProviders;
        }

        public void Start()
        {
            Trace.WriteLine("Client connected to Performance Monitoring Hub", "Information");

            _valueProvider.ToList().ForEach(x =>
                {
                    x.ValueReceived += OnValueReceived;
                });
        }

        void OnValueReceived(object sender, ValueReceivedEventArgs e)
        {
            Caller.showChartData(new { name = ((IPerformanceCounterReader)sender).Name, value = e.Value });
        }
    }
}
