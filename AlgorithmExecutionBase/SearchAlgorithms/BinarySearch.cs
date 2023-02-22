using Repository.DTO;
using Repository.Helpers;
using Repository.Interfaces;
using Repository.StringHelpers;
using System.Text;

namespace Algorithms.SearchAlgorithms
{
    public class BinarySearch : ISearchAlgorithm
    {
        public string Name => "Binary Search";
        public void ExecuteAlgorithm(int arrayLength)
        {
            ArrayAndTarget<int[], int> intArray = ArrayGenerator.GetOrderedIntArrayAndTarget(arrayLength: arrayLength);

            int result = ExecuteBinarySearch(intArray.Array, intArray.Target);

            PrintResult(result);
        }

        public static int ExecuteBinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                
                PrintLoop(left, right, mid);

                if (target == array[mid]) return mid;

                if (target < array[mid]) right = mid - 1;
                if (target > array[mid]) left = mid + 1;
            }

            return -1;
        }

        public static void PrintLoop(int left, int right, int mid)
        {
            StringBuilder line = new StringBuilder();
            line.Append(("Left: " + left).PadRight(12));
            line.Append(("Right:" + right).PadRight(12));
            line.Append(("Mid:  " + mid).PadRight(12));

            Console.WriteLine(line.ToString());
        }
        private static void PrintResult(int result)
        {
            Console.WriteLine();
            Console.WriteLine("Index: " + result);
            Console.WriteLine(StringHelpers.LINE_DIVIDER);
        }
    }
}