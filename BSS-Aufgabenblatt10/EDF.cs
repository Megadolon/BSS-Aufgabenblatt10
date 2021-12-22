using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class EDF : IScheduler
    {
        public double Solve(List<Process> processes)
        {
            processes.Sort((x, y) =>
            {
                if (x.deadline_ == y.deadline_) return x.executionTime_ > y.executionTime_ ? 1 : -1;
                if (x.deadline_ > y.deadline_) return 1;
                else return -1;
            });

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
