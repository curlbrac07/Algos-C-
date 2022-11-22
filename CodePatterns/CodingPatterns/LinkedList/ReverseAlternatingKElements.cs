
using System;
using System.Collections.Generic;
namespace LinkedList
{
    public static class ReverseAlternatingKElements
    {
        public static ListNode Reverse(ListNode head, int k)
        {
            ListNode result = null, lastNodeOfPrevSet = null;
            var current = head;

            bool canReverse = true;
            int index = 0;
            while(current != null)
            {
                var temp = current;
                ListNode prev = null;

                if (!canReverse)
                {
                    canReverse = true;
                    prev = current;
                    for (int i = 0; current != null && i < k; i++)
                    {
                        temp = current;
                        current = current.Next;

                    }
                }
                else
                {
                    for (int i = 0; current != null && i < k; i++)
                    {
                        var next = current.Next;
                        current.Next = prev;
                        prev = current;
                        current = next;
                    }
                    canReverse = false;
                    if (index == 0) result = prev;
                }

                if(lastNodeOfPrevSet != null)
                {
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

            ListNode result = ReverseAlternatingKElements.Reverse(head, 2);
            Console.WriteLine("Nodes are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }
        }
    }
}
