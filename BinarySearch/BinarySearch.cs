using Repository.DTO;
using Repository.Helpers;
using Repository.Interfaces;

namespace SearchAlgoritms
{
    public class BinarySearch : IAlgorithm
    {
        public string Name => "Binary Search";
        public AlgorithmType Type => AlgorithmType.Search;
        public void ExecuteAlgorithm()
        {
            ArrayAndTarget<int[], int> intArray = ArrayGenerator.GetIntArrayAndTarget();

            ExecuteBinarySearch(intArray.Array, intArray.Target);
        }

        public static int ExecuteBinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (target == nums[mid]) return mid;

                if (target < nums[mid]) right = mid - 1;
                if (target > nums[mid]) left = mid + 1;
            }

            return -1;
        }

    }
}