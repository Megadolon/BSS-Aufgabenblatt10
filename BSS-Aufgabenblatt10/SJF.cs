using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class SJF : IScheduler
    {
        public double Solve(List<Process> processes)
        {
            processes.Sort();

            int tick = 0;
            int readyTimes = 0;
            foreach (var process in processes)
            {
                tick += process.executionTime_;
                process.readyTime_ = tick;
                readyTimes += process.readyTime_;
            }

            return readyTimes / (double)processes.Count;
        }
    }
}
