
using System;
using System.Collections.Generic;
namespace LinkedList
{
    public static class ReverseEveryKElements
    {
        public static ListNode Reverse(ListNode head, int k)
        {
            ListNode result = null, lastNodeOfPrevSet = null;
            
            var current = head;
            var index = 0;
            while (current !=null) 
            {
               var temp = current;
               ListNode prev = null;
               for (int i = 0; current != null && i < k; i++)
               {
                   var next = current.Next;
                   current.Next = prev;
                   prev = current;
                   current = next;
               }

                if(index == 0)
                {
                    result = prev;
                }
                else
                {
                    if(lastNodeOfPrevSet != null)
                        lastNodeOfPrevSet.Next = prev;
                }

                lastNodeOfPrevSet = temp;

                index++;
            }
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
            head.Next.Next.Next.Next.Next.Next = new ListNode(7);
            head.Next.Next.Next.Next.Next.Next.Next = new ListNode(8);

            ListNode result = ReverseEveryKElements.Reverse(head, 3);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }
        }
    }
}
