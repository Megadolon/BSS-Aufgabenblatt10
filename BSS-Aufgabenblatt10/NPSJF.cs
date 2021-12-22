using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BSS_Aufgabenblatt10
{
    class NPSJF : IScheduler
    {
        struct Task : IComparable<Task>
        {
            public int executionTime_;
            public int processId_;
            public Task(int execTime, int processId)
            {
                executionTime_ = execTime;
                processId_ = processId;
            }

            public int CompareTo(Task other)
            {
                if (this.executionTime_ > other.executionTime_)
                    return 1;
                else
                    return -1;
            }
        }
        public double Solve(List<Process> processes)
        {
            //sortiere nach ready time then by exec time
            processes.Sort((x, y) =>
            {
                if (x.readyTime_ == y.readyTime_) return x.executionTime_ > y.executionTime_ ? 1 : -1;
                if (x.readyTime_ > y.readyTime_) return 1;
                else return -1;
            });
            //tasks die abgearbeitet werden
            List<Task> tasks = new List<Task>();
            //ticks
            int tick = 0;
            //akkumulierte Ready Times der Prozesse (siehe Skript)
            int readyTimes = 0;
            //counter der von der process Liste aufgenommenen tasks
            int tasksGotten = 0;
            //prozesse noch nicht abgearbeitet o der mögliche prozesse noch nicht aufgenommen
            bool tasksLeft = true;

            while (tasksLeft)
            {
                tasksLeft = false;
                //bereite prozesse registrieren
                for (int i = tasksGotten; i < processes.Count; i++)
                {
                    if (processes[i].readyTime_ == tick)
                    {
                        tasks.Add(new Task(processes[i].executionTime_, i));
                        tasksGotten++;
                    }
                    else break;
                }
                //aktive prozesse anzeigen
                Console.WriteLine($"-------time: {tick}");
                tasks.ForEach(t => {
                    Console.WriteLine($"execTime: {t.executionTime_} processID {t.processId_}");
                });
                Console.WriteLine("");

                //prozesse bearbeiten
                tick++;
                if (tasks.Count > 0)
                {
                    tasks[0] = new Task(tasks[0].executionTime_ - 1, tasks[0].processId_);
                    if (tasks[0].executionTime_ == 0)
                    {
                        int tickWithReadyOffset = tick - processes[tasks[0].processId_].readyTime_;
                        readyTimes += tickWithReadyOffset;
                        processes[tasks[0].processId_].readyTime_ = tickWithReadyOffset;
                        tasks.RemoveAt(0);
                    }
                }
                //tasks übrig?
                if (tasksGotten < processes.Count || tasks.Count > 0)
                {
                    tasksLeft = true;
                }
            }

            return readyTimes / (double)processes.Count;
        }
    }
}
