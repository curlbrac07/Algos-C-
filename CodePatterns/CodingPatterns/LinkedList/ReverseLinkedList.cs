
using System;
using System.Collections.Generic;
namespace LinkedList
{
    public static class ReverseLinkedList
    {
        public static ListNode Reverse(ListNode head)
        {
            var current = head;
            ListNode prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }


      

        public static void Run()
        {
            ListNode head = new ListNode(2);
            head.Next = new ListNode(4);
            head.Next.Next = new ListNode(6);
            head.Next.Next.Next = new ListNode(8);
            head.Next.Next.Next.Next = new ListNode(10);

            ListNode result = ReverseLinkedList.Reverse(head);
            Console.WriteLine("Nodes of the reversed LinkedList are: ");
            while (result != null)
            {
                Console.WriteLine(result.Value + " ");
                result = result.Next;
            }

        }


    }


    public class ListNode
    {
        public int Value { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int value)
        {
            this.Value = value;
        }
    }


}
