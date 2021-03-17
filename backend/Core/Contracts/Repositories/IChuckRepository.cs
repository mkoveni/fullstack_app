using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.Repositories
{
    public interface IChuckRepository
    {
        Task<List<string>> GetCategories();

        Task<List<ChuckNorrisJoke>> SearchJokes(string query);

        Task<ChuckNorrisJoke> GetRandomJokeFromCategory(string category);
    }
}