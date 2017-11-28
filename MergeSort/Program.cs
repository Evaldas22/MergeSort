using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedArray = new int[] {5,4,1,2,6,3};
            Console.WriteLine("Unsorted Array:");
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                Console.Write($"{unsortedArray[i]} ");
            }
            Console.WriteLine();

            int[] sortedArray = MergeSort(unsortedArray);
            Console.WriteLine("Sorted Array:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write($"{sortedArray[i]} ");
            }
            Console.WriteLine();
        }

        public static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1)    // this is the base case for the recursion
            {
                return numbers;
            }

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 > 0) // it's odd
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);
        }

        public static int[] Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First()) AddElementAndThenDelete(left, result);

                else AddElementAndThenDelete(right, result);
            }

            AddTheRemainingItemsFromList(left, result);
            AddTheRemainingItemsFromList(right, result);

            return result.ToArray();
        }

        private static void AddTheRemainingItemsFromList(List<int> list, List<int> result)
        {
            while (list.Count > 0)
            {
                AddElementAndThenDelete(list, result);
            }
        }

        private static void AddElementAndThenDelete(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }
    }
}