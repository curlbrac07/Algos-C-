using System;
namespace Algos.Greedy
{
    /*
     * Given weights and values of n items, we need to put these items in a knapsack of capacity W to get the maximum total 
     * value in the knapsack. 
     * 
     * Time : O(n log(n))   - n logn for sorting , o(n) for filling items and o(n) for looping to calculate cost
     * Space : O(n)
     * */

    public class FractionalKnapSack
    {
        public class KnapSackItem
        {
            public int Weight { get; set; }
            public int Value { get; set; }
            public int UnitValue => Value / Weight;

            public KnapSackItem(int w, int v)
            {
                Weight = w;
                Value = v;
            }
        }
        public FractionalKnapSack()
        {
        }

        public static void Test()
        {
            int[] wt = { 10, 40, 20, 30 };
            int[] val = { 60, 40, 100, 120 };
            int capacity = 50;

            var cost = Solve(wt, val, capacity);

            Console.WriteLine("Maximum total cost is : {0}", cost);
        }

        private static int Solve(int[] weights, int[] values, int capacity)
        {
            var items = new KnapSackItem[weights.Length];
            for (int i=0; i<weights.Length; i++)
            {
                items[i] = new KnapSackItem(weights[i], values[i]); 
            }

            //Greedy algo. As fractions are allowed, we need to find out value for 1 unit of weight and sort them
            Array.Sort(items, Compare);

            var remainingCapacity = capacity;
            var totalCost = 0;
            for(int i=0; i<items.Length; i++)
            {
                if (remainingCapacity == 0) break;
            
                if(items[i].Weight <= remainingCapacity)
                {
                    totalCost += items[i].Value;
                    remainingCapacity -= items[i].Weight;
                }
                else
                {
                    totalCost += items[i].UnitValue * remainingCapacity;
                    remainingCapacity = 0;
                    break;
                }
            }

            return totalCost;
        }

        private static int Compare(KnapSackItem item1, KnapSackItem item2)
        {
            if (item1.UnitValue == item2.UnitValue) return 0;
            else if (item1.UnitValue > item2.UnitValue) return -1;
            else return 1;
        }


    }

    
}
