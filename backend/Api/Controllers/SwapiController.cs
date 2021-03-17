using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Contracts.UseCases;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("swapi")]
    public class SwapiController : ControllerBase
    {

        IGetStarWarsCharacters _getStarWarsCharacters;

        public SwapiController(IGetStarWarsCharacters getStarWarsCharacters)
        {
            _getStarWarsCharacters = getStarWarsCharacters;
        }


        [HttpGet("people")]
        public async Task<List<StarWarCharacter>> GetPeople()
        {
            return await _getStarWarsCharacters.Handle();
        }
    }
}