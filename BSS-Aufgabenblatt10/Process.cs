using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class Process : IComparable<Process>
    {
        public Process(int executionTime, int deadline, int readyTime = 0)
        {
            executionTime_ = executionTime;
            readyTime_ = readyTime;
            deadline_ = deadline;
        }
        public int executionTime_;
        public int readyTime_;
        public int deadline_;

        public int CompareTo(Process other)
        {
            if (this.executionTime_ > other.executionTime_)
                return 1;
            else
                return -1;
        }
    }
}
