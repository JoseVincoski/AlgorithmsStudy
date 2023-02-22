using Repository.Interfaces;

namespace Repository.DTO
{
    public class AlgorithmsData
    {
        public ISearchAlgorithm Algorithm { get; set; }
        public int Number { get; set; }
        public AlgorithmType Type { get; set; }
    }
}