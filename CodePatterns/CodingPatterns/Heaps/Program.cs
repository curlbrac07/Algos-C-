using System;
using Library;

namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            Heap<int> h = new Heap<int>();

            h.Insert(13);
            h.Insert(15);
            h.Insert(7);
            h.Insert(21);
            Console.WriteLine(h);
            h.DeleteMin();
            Console.WriteLine(h);

      }
    }
}
