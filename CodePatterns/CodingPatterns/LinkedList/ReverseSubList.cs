
using System;
using System.Collections.Generic;
namespace LinkedList
{
    public static class ReverseSubList
    {
        public static ListNode Reverse(ListNode head, int p, int q)
        {

            if (p == q) return head;

            var current = head;
            ListNode prev = null;

            for(int i=0; current!=null && i < p -1; i++)
            {
                prev = current;
                current = current.Next;
            }

            var nodeBeforeReverse = prev;
            var lastNodeOfReverse = current;

            for(int i=0; current!=null && i< q-p + 1; i++)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            if(nodeBeforeReverse != null)
            {
               nodeBeforeReverse.Next = prev;
            }
            else
            {
                head = prev;
            }
            lastNodeOfReverse.Next = current;

            return head;

        }

        public static void Run()
        {
            ListNode head = new ListNode(1);
            head.Next = new ListNode(2);
            head.Next.Next = new ListNode(3);
            head.Next.Next.Next = new ListNode(4);
            head.Next.Next.Next.Next = new ListNode(5);

            ListNode result = ReverseSubList.Reverse(head, 2, 4);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }
        }
    }
}
