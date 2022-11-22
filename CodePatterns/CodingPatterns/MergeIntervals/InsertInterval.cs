using System;
using System.Collections.Generic;
namespace MergeIntervals
{
    public static class InsertInterval
    {
        public static List<Interval> Insert(List<Interval> intervals, Interval newInterval)
        {
            var result = new List<Interval>();

            if (intervals.Count == 0) return result;


            var isInserted = false;
            var startIndex = 1;
            var interval = intervals[0];
            if (newInterval.Start <= interval.Start)
            {
                interval = newInterval;
                startIndex = 0;
                isInserted = true;
            }

            int start = interval.Start;
            int end = interval.End;

            for(int i= startIndex; i< intervals.Count; i++)
            {
                
                interval = intervals[i];
                if (!isInserted && newInterval.Start <= interval.Start)
                {
                    interval = newInterval;
                    isInserted = true;
                    i = i - 1;
                }

                if(interval.Start > end)
                {
                    result.Add(new Interval(start, end));
                    start = interval.Start;
                    end = interval.End;
                }
                else
                {
                    end = Math.Max(end, interval.End);
                }
            }

            result.Add(new Interval(start, end));


            return result;
        }


        public static int SortCompare(Interval int1, Interval int2)
        {
            if (int1.Start > int2.Start) return 1;

            if (int1.Start == int2.Start) return 0;

            return -1;
        }

        public static void Run()
        {

            List<Interval> input = new List<Interval>();
            input.Add(new Interval(1, 3));
            input.Add(new Interval(5, 7));
            input.Add(new Interval(8, 12));
            Console.WriteLine("Intervals after inserting the new interval: ");
            foreach(var interval in InsertInterval.Insert(input, new Interval(4, 6)))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }
           

            input = new List<Interval>();
            input.Add(new Interval(1, 3));
            input.Add(new Interval(5, 7));
            input.Add(new Interval(8, 12));
            Console.WriteLine("Intervals after inserting the new interval: ");
            foreach (var interval in InsertInterval.Insert(input, new Interval(4, 10)))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }

            input = new List<Interval>();
            input.Add(new Interval(2, 3));
            input.Add(new Interval(5, 7));
            Console.WriteLine("Intervals after inserting the new interval: ");
            foreach (var interval in InsertInterval.Insert(input, new Interval(1, 4)))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }
        }

      
    }

 
}
