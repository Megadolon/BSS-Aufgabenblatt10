using System;
using System.Linq;
using System.Collections.Generic;

namespace BSS_Aufgabenblatt10
{
    class LLF : IScheduler
    {
        public double Solve(List<Process> processes)
        {
            processes.Sort((x, y) =>
            {
                if (x.deadline_-x.executionTime_ > y.deadline_ - y.executionTime_) return 1;
                else return -1;
            });

            int tick = 0;
            int readyTimes = 0;
            foreach (var process in processes)
            {
                tick += process.executionTime_;
                process.readyTime_ = tick;
                readyTimes += tick;
            }
            return readyTimes / (double)processes.Count;
        }
    }
}
