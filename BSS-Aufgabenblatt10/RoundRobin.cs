using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class RoundRobin : IScheduler
    {
        private int quantum_;
        public RoundRobin(int q)
        {
            if (q <= 0) throw new Exception("Quantum lower than 1!");
            quantum_ = q;
        }
        public double Solve(List<Process> processes)
        {
            int[] restTimes = new int[processes.Count];
            int counter = 0;
            processes.ForEach(p =>
            {
                restTimes[counter++] = p.executionTime_;
            });


            int readyTimes = 0;
            int tick = 0;
            bool tasksLeft = true;
            while (tasksLeft)
            {
                tasksLeft = false;
                for (int i = 0; i < restTimes.Length; i++)
                {
                    if (restTimes[i] <= 0) continue;

                    if (restTimes[i] <= quantum_)
                    {
                        tick += restTimes[i];
                        restTimes[i] = 0;
                        processes[i].waitTime_ = tick;
                        readyTimes += tick;
                    }
                    else
                    {
                        tick += quantum_;
                        restTimes[i] -= quantum_;
                        tasksLeft = true;
                    }
                }
            }


            return readyTimes / (double)processes.Count;
        }
    }
}
