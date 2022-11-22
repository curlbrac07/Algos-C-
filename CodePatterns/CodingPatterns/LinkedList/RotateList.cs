
using System;
using System.Collections.Generic;
namespace LinkedList
{
    public static class RotateList
    {
        public static ListNode Rotate(ListNode head, int rotations)
        {
            var length = 1;
            var current = head;
            while(current.Next != null)
            {
                current = current.Next;
                length++;
            }
            current.Next = head;

            var elementsToSkip = 0;
            if (rotations < length) elementsToSkip = rotations;
            else
            {
                rotations = rotations % length;
                elementsToSkip = length - rotations;
            }

            current = head;
            for(int i=0; i< elementsToSkip - 1; i++)
            {
                current = current.Next;
            }

            var result = current.Next;
            current.Next = null;

            return result;
            
        }

        public static void Run()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
            head.Next.Next.Next.Next.Next = new ListNode(6);

            ListNode result = RotateList.Rotate(head, 3);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }



            head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);
       

            result = RotateList.Rotate(head, 8);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }
        }


    }

}
