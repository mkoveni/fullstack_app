using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.UseCases
{
    public interface IGetRandomJoke
    {
        Task<ChuckNorrisJoke> Handle(string category);
    }
}