using Repository.DTO;
using System;
using UserInterfaceManager;

namespace Repository.Helpers
{
    public class ArrayGenerator
    {
        public static ArrayAndTarget<int[], int> GetIntArrayAndTarget(int min = 0, int max = 20, int arrayLength = 5)
        {
            var array = GenerateRandomIntArray(min, max, arrayLength);
            int target = GenerateTarget(array);

            var response = new ArrayAndTarget<int[], int>()
            {
                Array = array,
                Target = target
            };

            AlgorithmsGeneratorPrinter.PrintArrayAndTarget(response);

            return response;
        }

        public static ArrayAndTarget<int[], int> GetOrderedIntArrayAndTarget(int min = 0, int max = 5000, int arrayLength = 10)
        {
            int numberOfTargets = 1;

            int[] array = GenerateOrderedNonRepeatableIntArray(min, max, arrayLength);

            int target = GenerateTarget(array);

            var response = new ArrayAndTarget<int[], int>()
            {
                Array = array,
                Target = target
            };

            AlgorithmsGeneratorPrinter.PrintArrayAndTarget(response);
            return response;
        }

        private static int[] GenerateRandomIntArray(int min, int max, int arrayLength)
        {
            Random randNum = new Random();
            return Enumerable
                .Repeat(0, arrayLength)
                .Select(i => randNum.Next(min, max))
                .ToArray();
        }
        private static int[] GenerateOrderedNonRepeatableIntArray(int min, int max, int arrayLength)
        {
            Random randNum = new Random();

            List<int> responseArray = new List<int>();

            for (int i = 0; i <= arrayLength; i++)
            {
                int randomNumber = randNum.Next(min, max);

                while (responseArray.Contains(randomNumber))
                {
                    randomNumber = randNum.Next(min, max);
                }

                responseArray.Add(randomNumber);
            }

            return responseArray.OrderBy(i => i).ToArray();
        }
        private static int GenerateTarget(int[] array)
        {
            Random randNum = new Random();

            return array[randNum.Next(0, array.Length)];
        }
    }
}