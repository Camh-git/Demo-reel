using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_profiler
{
    class CPU_Info
    {
        public string CPU_name { get; set; }
        public int Physical_core_count { get; set; }
        public int Logical_core_count { get; set; }
        public double Core_clock { get; set; }
        public int Rated_IPC { get; set; }
        public CPU_Info(String name, int cores, int threads, double clock, int IPC)
        {
            CPU_name = name;
            Physical_core_count = cores;
            Logical_core_count = threads;
            Core_clock = clock;
            Rated_IPC = IPC;
        }
        }
    
}
