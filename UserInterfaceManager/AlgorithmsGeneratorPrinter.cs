using Repository.DTO;
using Repository.StringHelpers;
using System.Text;

namespace UserInterfaceManager
{
    public static class AlgorithmsGeneratorPrinter
    {
        
        public static void PrintArrayAndTarget(ArrayAndTarget<int[], int> arrayAndTarget)
        {
            PrintArray(arrayAndTarget.Array);
            Console.WriteLine("Target: " + arrayAndTarget.Target);

            Console.WriteLine();
        }

        public static void PrintArray(int[] array)
        {
            PrintArrays(array);
        }

        private static void PrintArrays(int[] array)
        {
            StringBuilder stringArray = new StringBuilder();
            foreach(int value in array)
            {
                stringArray.Append(value.ToString() + StringHelpers.ARRAY_DIVIDER);
            }
            stringArray.Length = stringArray.Length - StringHelpers.ARRAY_DIVIDER.Length;

            Console.Write("Array: ");
            Console.WriteLine($"[{stringArray}]");
        }
    }
}