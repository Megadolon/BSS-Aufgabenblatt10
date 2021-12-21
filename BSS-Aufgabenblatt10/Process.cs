using System;
using System.Collections.Generic;
using System.Text;

namespace BSS_Aufgabenblatt10
{
    class Process : IComparable<Process>
    {
        public Process(int executionTime)
        {
            executionTime_ = executionTime;
            readyTime_ = 0;
            deadline_ = -1;
        }
        public int executionTime_;
        public int readyTime_;
        public int deadline_;

        public int CompareTo(Process other)
        {
            if (other.executionTime_ <= this.executionTime_)
                return 1;
            else
                return -1;
        }
    }
}
