using Repository.DTO;
using Repository.Interfaces;
using Repository.StringHelpers;
using System.Text;

namespace UserInterfaceManager
{
    public class AlgorithmsDataPrinter
    {
        private readonly int NumberPadRight = 6;
        private readonly int TypePadRight = 10;
        public List<AlgorithmsData> AlgorithmsData { get; set; } = new List<AlgorithmsData>();

        public AlgorithmsDataPrinter()
        {
            int i = 1;
            IEnumerable<Type> _commands = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(t => t.GetInterfaces().Contains(typeof(ISearchAlgorithm)));
            foreach (Type _type in _commands)
            {
                ISearchAlgorithm algorithm = (ISearchAlgorithm)Activator.CreateInstance(_type);
                AlgorithmsData.Add(new AlgorithmsData() { Algorithm = algorithm, Number = i++, Type = AlgorithmType.Search });
            }
        }
        public AlgorithmsData SelectAlgorithm()
        {
            StringBuilder line = new StringBuilder();
            line.Append("Number".PadRight(NumberPadRight));
            line.Append(" | ");
            line.Append("Type".PadRight(TypePadRight));
            line.Append(" | ");
            line.Append("Name");
            Console.WriteLine(line.ToString());

            Console.WriteLine(StringHelpers.LINE_DIVIDER);
            foreach (AlgorithmsData algorithm in AlgorithmsData)
            {
                line.Clear();
                line.Append(algorithm.Number.ToString().PadRight(NumberPadRight));
                line.Append(" | ");
                line.Append(algorithm.Type.ToString().PadRight(TypePadRight));
                line.Append(" | ");
                line.Append(algorithm.Algorithm.Name);
                Console.WriteLine(line.ToString());
            }

            return GetTypedAlgorithm();
        }
        public void ExecuteSelectedAlgorithm(AlgorithmsData selectedAlgorithm)
        {

            if (selectedAlgorithm.Type == AlgorithmType.Search)
            {
                ExecuteSearchAlgorithm(selectedAlgorithm);
            }

            
        }
        private void ExecuteSearchAlgorithm(AlgorithmsData algorithm)
        {
            Console.WriteLine("Executing " + algorithm.Algorithm.Name);
            Console.Write("Array length: ");
            string typedNumber = Console.ReadLine();

            int intNumber;
            while (int.TryParse(typedNumber, out intNumber) == false)
            {
                Console.Write("Type an integer: ");
                typedNumber = Console.ReadLine();
            }

            algorithm.Algorithm.ExecuteAlgorithm(intNumber - 1);
        }
        private AlgorithmsData GetTypedAlgorithm()
        {
            Console.Write("Type the number of the algorithm you want to be executed: ");
            string typedNumber = Console.ReadLine();

            bool isValidInt = int.TryParse(typedNumber, out int intNumber);
            if (isValidInt)
            {
                AlgorithmsData algorithm = GetAlgorithmByNumber(intNumber);
                if (algorithm == null)
                {
                    isValidInt = false;
                }
                else return algorithm;
            }

            while(isValidInt == false)
            {
                Console.WriteLine("Type an integer number that's on the list: ");
                typedNumber = Console.ReadLine();

                isValidInt = int.TryParse(typedNumber, out intNumber);
                if (isValidInt)
                {
                    AlgorithmsData algorithm = GetAlgorithmByNumber(intNumber);
                    if (algorithm == null) isValidInt = false;
                    else return algorithm;
                }
            }

            return null;
        }
        private AlgorithmsData? GetAlgorithmByNumber(int algorithmNumber)
        {
            return AlgorithmsData.Find(a => a.Number == algorithmNumber);
        }
    }
}