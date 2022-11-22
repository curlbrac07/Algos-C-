using System;
using System.Collections.Generic;
namespace MergeIntervals
{
    public static class ConflictingAppointments
    {
        public static bool CanAttendAllAppointments(Interval[] intervals)
        {
            Array.Sort(intervals, SortCompare);

            if (intervals.Length == 0) return false;

            for(int i=1; i< intervals.Length; i++)
            {
                if (intervals[i].Start < intervals[i-1].End) return false;
            }

            return true;

        }


        public static int SortCompare(Interval int1, Interval int2)
        {
            if (int1.Start > int2.Start) return 1;

            if (int1.Start == int2.Start) return 0;

            return -1;
        }

        public static void Run()
        {
            Interval[] intervals = { new Interval(1, 4), new Interval(2, 5), new Interval(7, 9) };
            var result = ConflictingAppointments.CanAttendAllAppointments(intervals);
            Console.WriteLine("Can attend all appointments: " + result);

            Interval[] intervals1 = { new Interval(6, 7), new Interval(2, 4), new Interval(8, 12) };
            result = ConflictingAppointments.CanAttendAllAppointments(intervals1);
            Console.WriteLine("Can attend all appointments: " + result);

            Interval[] intervals2 = { new Interval(4, 5), new Interval(2, 3), new Interval(3, 6) };
            result = ConflictingAppointments.CanAttendAllAppointments(intervals2);
            Console.WriteLine("Can attend all appointments: " + result);

        }


    }

 
}
