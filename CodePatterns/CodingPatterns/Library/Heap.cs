using System;
namespace Library
{
    public class Heap<T> where T : IComparable
    {
        private enum HeapType
        {
            Min,
            Max
        };

        private static int CAPACITY = 2;
        private int size;
        private T[] heap;
        private readonly HeapType heapType;


        public Heap(bool isMaxHeap = false)
        {
            heapType = isMaxHeap ? HeapType.Max : HeapType.Min;
            size = 0;
            heap = new T[CAPACITY];
        }


        public void Insert(T x)
        {
            if (size == heap.Length - 1) DoubleSize();

            var pos = ++size;

            while(pos > 1 && Compare(heap[pos/2], x) > 0)   //pos > 1 && heap[pos/2] > x
            {
                heap[pos] = heap[pos / 2];
                pos = pos / 2;
            }

            heap[pos] = x;
           
        }

        public T DeleteMin()
        {
            if (size == 0) throw new Exception("No elements exist");

            var min = heap[1];

            var pos = 1;

            heap[pos] = heap[size--];

            HeapifyDown(pos);

            return min;
        }


        private void HeapifyDown(int pos)
        {
            while(HasChildren(pos))
            {
                var smallestChildNode = SmallestChildNode(pos);
                if(Compare(heap[pos],heap[smallestChildNode]) < 0) //heap[pos] < heap[smallestChildNode])
                {
                    break;
                }

                //Swap
                var temp = heap[smallestChildNode];
                heap[smallestChildNode] = heap[pos];
                heap[pos] = temp;
                pos = smallestChildNode; 
            }

        }

        private int SmallestChildNode(int pos)
        {
            var left = pos * 2;
            var right = left + 1;

            if (right > size || Compare(heap[left] , heap[right]) < 0) return left;  //right > size || heap[left] < heap[right]
            return right;
        }

        private bool HasChildren(int pos)
        {
            return (pos * 2) <= size;
        }
        
        public void DoubleSize()
        {
            var old = heap;
            heap = new T[heap.Length * 2];
            Array.Copy(old, heap, old.Length);
        }

        private int Compare(int initialIndex, int contenderIndex)
        {
            T initial = heap[initialIndex];
            T contender = heap[contenderIndex];
            int value = initial.CompareTo(contender);
            if (heapType == HeapType.Max) value = -value;
            return value;
        }

        private int Compare(T x, T y)
        {
            int value = x.CompareTo(y);
            if (heapType == HeapType.Max) value = -value;
            return value;
        }

        public override string ToString()
        {
            string temp = "";
            for (int k = 1; k <= size; k++) temp += heap[k] + " ";
            return temp; 
        }



    }
}
