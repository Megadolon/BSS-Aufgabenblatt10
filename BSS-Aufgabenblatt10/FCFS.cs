﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class FCFS : IScheduler
    {
        public double Solve(List<Process> processes)
        {
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
