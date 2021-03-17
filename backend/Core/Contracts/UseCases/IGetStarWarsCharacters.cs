using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.UseCases
{
    public interface IGetStarWarsCharacters
    {
        Task<List<StarWarCharacter>> Handle();
    }
}