using System;
using System.Collections.Generic;
namespace MergeIntervals
{
    public static class MergeOverlappingIntervals
    {
        public static List<Interval> Merge(List<Interval> intervals)
        {
            var result = new List<Interval>();

            if (intervals.Count == 0) return result;

            intervals.Sort(SortCompare);

            Interval interval =intervals[0];
            int start = interval.Start;
            int end = interval.End;

            for(int i=1; i< intervals.Count; i++)
            {
                interval = intervals[i];

                if(interval.Start > end)  //NextOne didnt overlap with (start, end)
                {
                    result.Add(new Interval(start, end));
                    start = interval.Start;
                    end = interval.End;
                }
                else // overlapped. Start remains same. But end = Max(end, interval.end)
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
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));
            Console.WriteLine("Merged intervals: ");
            foreach(var interval in MergeOverlappingIntervals.Merge(input))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }
           

            input = new List<Interval>();
            input.Add(new Interval(6, 7));
            input.Add(new Interval(2, 4));
            input.Add(new Interval(5, 9));
            Console.WriteLine("Merged intervals: ");
            foreach (var interval in MergeOverlappingIntervals.Merge(input))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }

            input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 6));
            input.Add(new Interval(3, 5));
            Console.WriteLine("Merged intervals: ");
            foreach (var interval in MergeOverlappingIntervals.Merge(input))
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }
        }

      
    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
