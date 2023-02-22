namespace EstudoAlgoritmos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var algorithm = new Solution();
            algorithm.RunningSum(new int[] { 3, 1, 2, 10, 1 });
        }

        public class Solution
        {
            public int[] RunningSum(int[] nums)
            {
                List<int> returnnums = new List<int>();
                returnnums.Add(nums[0]);

                for(int i = 1; i <= nums.Length - 1; i++)
                {
                    returnnums.Add(nums[i] + returnnums[i - 1]);
                }

                return returnnums.ToArray();
            }
        }
    }
}