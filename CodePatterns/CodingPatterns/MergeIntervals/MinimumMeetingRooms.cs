using System;
using System.Collections.Generic;
namespace MergeIntervals
{
    public static class MinimumMeetingRooms
    {
        public static int FindMinimumMeetingRooms(List<Meeting> meetings)
        {
            meetings.Sort(SortCompare);

            var meeting = meetings[0];
            int start = meeting.Start;
            int end = meeting.End;

            var overlapCount = 0;
            for(int i=1; i< meetings.Count; i++)
            {
                meeting = meetings[i];

                if (meeting.Start < end)
                {
                    end = Math.Min(end, meeting.End);
                    overlapCount++;
                }
                else
                {
                    start = meeting.Start;
                    end = meeting.End;

                }
            }

            return 1 + overlapCount;

        }


        public static int SortCompare(Meeting int1, Meeting int2)
        {
            if (int1.Start > int2.Start) return 1;

            if (int1.Start == int2.Start) return 0;

            return -1;
        }

        public static void Run()
        {
            var input = new List<Meeting>();
            input.Add(new Meeting(4, 5));
            input.Add(new Meeting(2, 3));
            input.Add(new Meeting(2, 4));
            input.Add(new Meeting(3, 5));
            int result = MinimumMeetingRooms.FindMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

            input = new List<Meeting>();
            input.Add(new Meeting(1, 4));
            input.Add(new Meeting(2, 5));
            input.Add(new Meeting(7, 9));
            result = MinimumMeetingRooms.FindMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

            input = new List<Meeting>();
            input.Add(new Meeting(6, 7));
            input.Add(new Meeting(2, 4));
            input.Add(new Meeting(8, 12));
            result = MinimumMeetingRooms.FindMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

            input = new List<Meeting>();
            input.Add(new Meeting(1, 4));
            input.Add(new Meeting(2, 3));
            input.Add(new Meeting(3, 6));
            result = MinimumMeetingRooms.FindMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

            input = new List<Meeting>();
            input.Add(new Meeting(4, 5));
            input.Add(new Meeting(2, 3));
            input.Add(new Meeting(2, 4));
            input.Add(new Meeting(3, 5));
            result = MinimumMeetingRooms.FindMinimumMeetingRooms(input);
            Console.WriteLine("Minimum meeting rooms required: " + result);

        }


    }


public class Meeting
{
    public int Start { get; set; }
    public int End { get; set; }

    public Meeting(int start, int end)
    {
        this.Start = start;
        this.End = end;
    }
}

 
}
