using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Contracts.UseCases
{
    public interface IGetCategories
    {
        Task<List<string>> Handle();
    }
}