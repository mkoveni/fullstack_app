using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Resource;
using Core.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Contracts.UseCases;

namespace Api.Controllers
{
    [ApiController]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        ISearchJokes _searchJokes;
        ISearchCharacters _searchCharacters;

        public SearchController(ISearchJokes searchJokes, ISearchCharacters searchCharacters)
        {
            _searchJokes = searchJokes;
            _searchCharacters = searchCharacters;
        }

        [HttpGet]
        public async Task<SearchResponseModel> Search([FromQuery] string query)
        {

            var tasks = new List<Task> {
               _searchJokes.Handle(query),
                _searchCharacters.Handle(query)
            };

            await Task.WhenAll(tasks);

            SearchResponseModel searchResponseModel = new SearchResponseModel
            {
                Chuck = (tasks[0] as Task<List<ChuckNorrisJoke>>).Result,
                Swapi = (tasks[1] as Task<List<StarWarCharacter>>).Result
            };


            return searchResponseModel;
        }
    }
}