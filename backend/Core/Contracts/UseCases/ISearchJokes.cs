using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.UseCases
{
    public interface ISearchJokes
    {
        Task<List<ChuckNorrisJoke>> Handle(string query);
    }
}