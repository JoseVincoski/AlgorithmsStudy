using Repository.DTO;

namespace Repository.Interfaces
{
    public interface ISearchAlgorithm
    {
        public string Name { get; }
        public void ExecuteAlgorithm(int arrayLength);
    }
}