using System.Collections.Generic;
using System;
using System.Linq;

namespace BSS_Aufgabenblatt10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Process> processes = new List<Process>();

            processes.Add(new Process(22, 25, 0));
            processes.Add(new Process(2, 7, 0));
            processes.Add(new Process(3, 10, 4));
            processes.Add(new Process(5, 15, 4));
            processes.Add(new Process(8, 8, 4));


            IScheduler scheduler;

            scheduler = new FirstComeFirstServe();
            SolveAndShow(new List<Process>(processes), scheduler);
            
            scheduler = new ShortestJobFirst();
            SolveAndShow(new List<Process>(processes), scheduler);

            scheduler = new EarliestDeadlineFirst();
            SolveAndShow(new List<Process>(processes), scheduler);

            scheduler = new LeastLaxityFirst();
            SolveAndShow(new List<Process>(processes), scheduler);

            scheduler = new RoundRobin(3);
            SolveAndShow(new List<Process>(processes), scheduler);

            # region aufgabe 2
            Console.WriteLine("Aufgabe 2:");
            for (int i = 1; i < 10; i++)
            {
                scheduler = new RoundRobin(i);
                Console.WriteLine(scheduler.GetType().Name + " " + i);
                Console.WriteLine("Wait Times: " + scheduler.Solve(new List<Process>(processes)));
                Console.WriteLine("");
            }
            #endregion
                
            # region aufgabe 3
            Console.WriteLine("Aufgabe 3:");
            scheduler = new PreemptiveShortestJobFirst();
            SolveAndShow(new List<Process>(processes), scheduler);

            scheduler = new NonPreemptiveShortestJobFirst();
            SolveAndShow(new List<Process>(processes), scheduler);
            #endregion
                
        }

        private static void SolveAndShow(List<Process> processes, IScheduler scheduler)
        {
            Console.WriteLine(scheduler.GetType().Name);
            Console.WriteLine("Wait Times: " + scheduler.Solve(processes));
            Console.WriteLine("");
        }
    }
}
