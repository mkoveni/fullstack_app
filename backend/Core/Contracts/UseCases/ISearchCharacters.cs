using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.UseCases
{
    public interface ISearchCharacters
    {
        Task<List<StarWarCharacter>> Handle(string query);
    }

}