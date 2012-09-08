using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SystemMonitor.WorkerRole
{
    public class ValueReceivedEventArgs : EventArgs
    {
        public ValueReceivedEventArgs(float value)
        {
            this.Value = value;
        }

        public float Value { get; private set; }
    }

    public interface IPerformanceCounterReader
    {
        event EventHandler<ValueReceivedEventArgs> ValueReceived;
        void ReadValue();
        string Name { get; }
    }

    public class CpuPerformanceReader : IPerformanceCounterReader
    {
        PerformanceCounter _cpuCounter;

        public CpuPerformanceReader()
        {
            _cpuCounter = new PerformanceCounter();
            _cpuCounter.CategoryName = "Processor";
            _cpuCounter.CounterName = "% Processor Time";
            _cpuCounter.InstanceName = "_Total";
        }

        public event EventHandler<ValueReceivedEventArgs> ValueReceived;

        public void ReadValue()
        {
            var value = _cpuCounter.NextValue();

            if (ValueReceived != null)
                ValueReceived(this, new ValueReceivedEventArgs(value));
        }

        public string Name
        {
            get { return "CPU"; }
        }
    }

    public class MemoryPerformanceReader : IPerformanceCounterReader
    {
        PerformanceCounter _cpuCounter;

        public event EventHandler<ValueReceivedEventArgs> ValueReceived;

        public MemoryPerformanceReader()
        {
            _cpuCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public void ReadValue()
        {
            var value = _cpuCounter.NextValue();

            if (ValueReceived != null)
                ValueReceived(this, new ValueReceivedEventArgs(value));
        }

        public string Name
        {
            get { return "Memory"; }
        }
    }

    public class NetClrMemoryPerformanceReader : IPerformanceCounterReader
    {
        public event EventHandler<ValueReceivedEventArgs> ValueReceived;

        PerformanceCounter _counter;

        public NetClrMemoryPerformanceReader()
        {
            _counter = new PerformanceCounter(".NET CLR Memory", "# bytes in all heaps", Process.GetCurrentProcess().ProcessName);
        }

        public void ReadValue()
        {
            var value = _counter.NextValue();

            if (ValueReceived != null)
                ValueReceived(this, new ValueReceivedEventArgs(value));
        }

        public string Name
        {
            get { return ".NET Memory"; }
        }
    }


}
