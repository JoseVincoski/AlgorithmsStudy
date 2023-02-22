using Repository.DTO;
using Repository.Helpers;
using Repository.Interfaces;
using Repository.StringHelpers;
using System.Text;

namespace Algorithms.SearchAlgorithms
{
    public class LinearSearch : ISearchAlgorithm
    {
        public string Name => "Linear Search";

        public void ExecuteAlgorithm(int arrayLength)
        {
            ArrayAndTarget<int[], int> intArray = ArrayGenerator.GetIntArrayAndTarget(arrayLength: arrayLength);

            int result = ExecuteBinarySearch(intArray.Array, intArray.Target);

            PrintResult(result);
        }

        public static int ExecuteBinarySearch(int[] array, int target)
        {

            return -1;
        }

        public static void PrintLoop()
        {
            
        }
        private static void PrintResult(int result)
        {
            Console.WriteLine();
            Console.WriteLine("Index: " + result);
            Console.WriteLine(StringHelpers.LINE_DIVIDER);
        }
    }
}