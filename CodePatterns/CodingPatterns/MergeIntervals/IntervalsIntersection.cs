using System;
using System.Collections.Generic;
namespace MergeIntervals
{
    public static class IntervalsIntersection
    {
        public static Interval[] Merge(Interval[] arr1, Interval[] arr2)
        {
            var result = new List<Interval>();
            int i = 0;
            int j = 0;
            while(i < arr1.Length && j < arr2.Length)
            {

                if(arr2[j].Start <= arr1[i].End) // There is intersection
                {
                    var start = Math.Max(arr1[i].Start, arr2[j].Start);
                    var end = Math.Min(arr1[i].End, arr2[j].End);
                    result.Add(new Interval(start, end));
                    if (arr1[i].End < arr2[j].End)
                    {
                        i++;
                    }
                    else if (arr1[i].End == arr2[j].End)
                    {
                        i++;
                        j++;
                    }
                    else j++;
                }
                else
                {
                    i++;
                }
            }

            return result.ToArray();

        }


        public static int SortCompare(Interval int1, Interval int2)
        {
            if (int1.Start > int2.Start) return 1;

            if (int1.Start == int2.Start) return 0;

            return -1;
        }

        public static void Run()
        {
            Interval[] input1 = new Interval[] { new Interval(1, 3), new Interval(5, 6), new Interval(7, 9) };
            Interval[] input2 = new Interval[] { new Interval(2, 3), new Interval(5, 7) };
            Interval[] result = IntervalsIntersection.Merge(input1, input2);
            Console.WriteLine("Intervals Intersection: ");
            foreach (var interval in result)
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }
        
            input1 = new Interval[] { new Interval(1, 3), new Interval(5, 7), new Interval(9, 12) };
            input2 = new Interval[] { new Interval(5, 10) };
            result = IntervalsIntersection.Merge(input1, input2);
            Console.WriteLine("Intervals Intersection: ");
            foreach (var interval in result)
            {
                Console.WriteLine("[{0},{1}]", interval.Start, interval.End);
            }

        }

      
    }

 
}
