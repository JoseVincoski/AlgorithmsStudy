using Repository.DTO;

namespace Repository.Interfaces
{
    public interface IAlgorithm
    {
        public string Name { get; }
        public AlgorithmType Type { get; }
    }
}