using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    interface IScheduler
    {
        public abstract double Solve(List<Process> processes);
    }
}
