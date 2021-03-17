using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts.Repositories
{
    public interface ISwapiRepository
    {
        Task<List<StarWarCharacter>> GetPeople();
        Task<List<StarWarCharacter>> Search(string query);
    }
}